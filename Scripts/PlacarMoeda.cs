using Godot;
using System;

public class PlacarMoeda : Node2D
{
	private Label label;
	private uint valor;

	public uint Valor
	{
		get => valor ;
		set
		{
			valor = value;
			var valorCortado = (value > 9999) ? 9999 : value;
			label.Text = string.Format("{0:D4}", valorCortado);
		}
	}

	public override void _Ready() {
		label = GetNode<Label>("Label");
		label.Text = "0000";
	}

}
