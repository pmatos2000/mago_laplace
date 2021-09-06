using Godot;
using System;



public class JogadorControler : IControler
{
	public JogadorControler() { }

	public Controle ObterComandos(Sensor _ )
	{
		return new Controle
		{
			Esquerda = Input.IsActionPressed("ui_left"),
			Direita = Input.IsActionPressed("ui_right"),
			X = Input.IsActionJustPressed("ui_a"),
		};
	}
}
