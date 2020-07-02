using Godot;
using System;

public class PlacarMana : Node2D, Valor
{
	
	//Frames
	private const int _FRAME_MANA_CHEIA = 0;
	private const int _FRAME_MEIA_MANA = 1;
	
	private Sprite[] _mana = new Sprite[10];
	private int _valor;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Godot.Collections.Array filhos =  GetChildren();
		for(int i = 0; i < 10; i++){
			_mana[i] = (Sprite) filhos[i];
			_mana[i].Visible = false;
		}
	}
	
	public void SetValor(int valor){
		_valor = valor;
		if(_valor > 20){
			_valor = 20;
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
		bool impar = (_valor % 2 == 1);
		int valor = _valor/2;
		
		for(int i = 0; i < 10; i++){
			if(i < valor){
				_mana[i].Visible = true;
				_mana[i].Frame = _FRAME_MANA_CHEIA;
			}
			else{
				_mana[i].Visible = false;
			}
		}
		
		if(impar == true){
			_mana[valor].Visible = true;
			_mana[valor].Frame = _FRAME_MEIA_MANA;
		}
	}
}
