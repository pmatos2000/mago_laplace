using Godot;
using System;

public class PlacarRelogio : Node2D, Valor
{
	private Label _label;
	private int _valor;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready(){
		_label = GetNode<Label>("Label");
	}
	
	public void SetValor(int valor){
		_valor = valor;
		if(_valor > 599){ //Tempo maximo para 9min e 59 seg
			_valor = 599;
		}
		else if(_valor < 0){
			_valor = 0;
		}
		_Atualiza();
	}
	
	public int GetValor(){
		return _valor;
	}
	
	private void _Atualiza(){
		int m = _valor/60; //Minutos
		int s = _valor%60; //Segundos
		_label.Text = string.Format("{0:D}:{1:D2}",m,s);
	}
}
