using Godot;
using System;

public class Inimigo : Vivo
{
	//Caminho da versão controlavel
	//private string _caminhoControlavel;
	
	//Salva a referenciar
	/*
	protected Node2D _ref;
	
	public Node2D Ref{
		set => _ref = value;
	}

	public override void _Ready(){
		base._Ready();
		AddToGroup("Inimigo");
		_DirInicial();
	}
	
	
	protected override void _SensorCorpoEntrou(Node corpo){
		if(corpo is Jogador){
			Jogador jogador = (Jogador) corpo;
			jogador.Dano();
			
		}
	}
	
	protected void _DirInicial(){
		if(_ref != null){
			if(GlobalPosition.x > _ref.GlobalPosition.x){
				controle.esq = true;
			}
			else{
				controle.dir = true;
			}
		}
		else{
			Random randNum = new Random();
			if(randNum.Next() % 2 == 0){
				controle.esq = true;
			}
			else{
				controle.dir = true;
			}
		}
	}
	*/
	
}
