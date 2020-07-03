using Godot;
using System;

public class GeradorCaranguejoLaranja : GeradorInimigo
{
	private static string _CAMINHO = "res://Cenas/Inimigos/CaranguejoLaranja.tscn";
	
	protected override void _SetValoresPadrao(){
		CaminhoCena = _CAMINHO;
	}
	
	
	
	
}
