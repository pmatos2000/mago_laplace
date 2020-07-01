using Godot;
using System;

public class CameraLevel : Camera2D
{
	[Export]
	private NodePath caminhoRef;
	
	private Node2D _ref;
	
	// Declare member variables here. Examples:
	public override void _Ready(){
		_Referencias();
		_Limites();
	}
	
	// Salva as referencias 
	private void _Referencias(){
		_ref = GetNode<Node2D>(caminhoRef);
		if(_ref == null){
			GD.Print("Camera sem uma referência valida");
			GetTree().Quit();
		}
	}
	
	private void _Limites(){
		//Pega os limtes ja definidos
		float limEsq = LimitLeft;
		float limDir = LimitRight;
		float limTop = LimitTop;
		float limInf = LimitBottom;
		
	
		
		Godot.Collections.Array tileMaps;
		TileMap tileMap;
		Rect2 rect;
		
		tileMaps = GetTree().GetNodesInGroup("TileMap");
		foreach(Node node in tileMaps){
			if(node is TileMap){
				tileMap = (TileMap) node;
				rect = tileMap.GetUsedRect();
				
				//Calcula os limites
				limEsq = Math.Min(limEsq, rect.Position.x * tileMap.CellSize.x);
				limDir = Math.Max(limDir, rect.End.x * tileMap.CellSize.x);
				limTop = Math.Min(limTop, rect.Position.y * tileMap.CellSize.y);
				limInf = Math.Max(limInf, rect.End.y * tileMap.CellSize.y);
				
			}
		}
		
		
		//Atualiza o limites
		LimitLeft = (int) limEsq;
		LimitRight = (int) limDir;
		LimitTop = (int) limTop - 160;
		LimitBottom = (int) limInf - 40;
		
	}
	
	// Atualiza em todos os quadros
	public override void _Process(float delta){
		Position = _ref.GlobalPosition;
	}


//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
