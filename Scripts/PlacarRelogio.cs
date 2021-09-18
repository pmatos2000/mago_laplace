using Godot;
using System;

public class PlacarRelogio : Node2D
{
	private Label label;
	
	public override void _Ready(){
		label = MetodosUteis.ObterNo<Label>(this, "Label");
	}
	
	public void SetValor(int tempo){
		int minutos = tempo / 60;
		int segundos = tempo % 60;
		label.Text = string.Format("{0:D}:{1:D2}", minutos, segundos);
	}
}
