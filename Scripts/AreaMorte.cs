using Godot;
using System;

public class AreaMorte : Node{
	/*
	public override void _Ready(){
		
		//Ler todos os filhos do tipo Area2D e conecta o sinal
		Godot.Collections.Array filhos =  GetChildren();
		foreach(Node node in filhos){
			if(node is Area2D){
				node.Connect("body_entered", this, nameof(_SensorCorpoEntrou));
			}
		}
	}
	
	private void _SensorCorpoEntrou(Node corpo){
		if(corpo is Vivo){
			Vivo vivo = (Vivo) corpo;
			vivo.Morte();
		}
	}
	*/
}
