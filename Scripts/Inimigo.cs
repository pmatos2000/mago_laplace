using Godot;
using System;

public class Inimigo : Vivo
{
	//Caminho da versão controlavel
	//private string _caminhoControlavel;
	
	//Salva a referencia do jogador
	protected Jogador _jogador;
	
	public Jogador Jogador{
		set => _jogador = value;
	}

	public override void _Ready(){
		base._Ready();
		AddToGroup("Inimigo");
	}
	
	protected override void _SensorCorpoEntrou(Node corpo){
		if(corpo is Jogador){
			Jogador jogador = (Jogador) corpo;
			jogador.Dano();
		}
	}
	
}
