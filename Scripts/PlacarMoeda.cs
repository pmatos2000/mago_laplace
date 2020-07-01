using Godot;
using System;

public class PlacarMoeda : Node2D, Valor
{
	private Label _label;
	private int _valor;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready(){
		_label = GetNode<Label>("Label");
	}
	
	public void SetValor(int valor){
		_valor = valor;
		if(_valor > 9999){ //O valor maximo para 4 digitos
			_valor = 9999;
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
		_label.Text = string.Format("{0:D4}",_valor);
	}
}
