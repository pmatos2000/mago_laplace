using Godot;
using System;

public class Moeda : Coletavel
{
	protected override void _SensorCorpoEntrou(Node corpo){
		if(corpo is Jogador){
			Jogador jogador = (Jogador) corpo;
			jogador.AddMoeda();
			QueueFree();
		}
	}
}
