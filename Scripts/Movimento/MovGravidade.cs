using Godot;
using System;

public class MovGravidade : NodeMov
{
	private static int g = 15;

	protected override void _Pos(float delta){
		_mov.y += g;
		if(_mov.y > 500) _mov.y = 500;
		Position += _mov * delta;
	}
}
