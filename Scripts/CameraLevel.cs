using Godot;
using System;

public class CameraLevel : Camera2D
{
	[Export]
	private NodePath caminhoRef = null;
	private Node2D noRef;
	
	// Declare member variables here. Examples:
	public override void _Ready(){
		ObterReferencias();
	}
	
	// Salva as referencias 
	private void ObterReferencias(){
		noRef = MetodosUteis.ObterNo<Node2D>(this, caminhoRef);
	}
	
	
	// Atualiza em todos os quadros
	public override void _Process(float delta){
		Position = noRef.GlobalPosition;
		GD.Print(noRef.GlobalPosition);
	}

}
