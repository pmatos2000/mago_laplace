using Godot;
using System;

public class Coletavel : Entidade{
	
	public override void _Ready(){
		base._Ready();
		Fisica = false;
	}
}
