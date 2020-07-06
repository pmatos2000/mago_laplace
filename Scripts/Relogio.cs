using Godot;
using System;

public class Relogio : Node
{
	[Signal]
	public delegate void SinalModRelogio(int valor);
	[Signal]
	public delegate void SinalRelogioFim();
	
	private Memoria _memLocal;
	
	public override void _Ready(){
		_memLocal = GetNode<Memoria>("/root/MemLocal");
	}
	
	
	public int TempoMax{
		set{
			_tempoMax = value;
			if(_tempoMax > 599){ // 9:59
				_tempoMax = 599;
			}
			else if(_tempoMax < 0){
				_tempoMax = 0;
			}
		}
	}
	
	private int _tempoMax = 0;
	private float _tempoTotal = 0;
	private bool _ativo = false;
	private int _difAntes = 0;

	public override void _Process(float delta){
		if (_ativo){
			_tempoTotal += delta;
			int dif = (int) Math.Round(_tempoMax - _tempoTotal);
			if(_difAntes != dif){
				_difAntes = dif;
				EmitSignal(nameof(SinalModRelogio), dif);
				//Salva na memoria
				_memLocal.Add("Relogio", dif);
				
			}
			if(dif <= 0){
				dif = 0;
				_difAntes = 0;
				_ativo = false;
				EmitSignal(nameof(SinalRelogioFim));
			}

			
		}
		
	}
	
	public void Inicia(){
		_ativo = true;
		_difAntes = 0;
	}
}
