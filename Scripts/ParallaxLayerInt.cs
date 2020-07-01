using Godot;
using System;

public class ParallaxLayerInt : ParallaxLayer
{
	public override void _Process(float delta){
		Position = Position.Round();
	}
}
