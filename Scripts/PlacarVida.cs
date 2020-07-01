using Godot;
using System;

public class PlacarVida : Node2D, Valor
{
	private Sprite[] _coracoes = new Sprite[10];
	private int _valor;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Godot.Collections.Array filhos =  GetChildren();
		for(int i = 0; i < 10; i++){
			_coracoes[i] = (Sprite) filhos[i];
			_coracoes[i].Visible = false;
		}
	}
	
	public void SetValor(int valor){
		_valor = valor;
		if(_valor > 10){
			_valor = 10;
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
		for(int i = 0; i < 10; i++){
			_coracoes[i].Visible = (i < _valor);
		}
	}
}
