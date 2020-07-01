using Godot;
using System;

public class Vivo : Entidade
{
	//Dados vida
	private int _vida = 1;
	private int _mana = 0;
	private int _vidaMax = 1;
	private int _manaMax = 0;
		
	//Sinais
	[Signal]
	public delegate void SinalMorte();
	[Signal]
	public delegate void SinalModVida(int valor);
	[Signal]
	public delegate void SinalModMana(int valor);
	[Signal]
	public delegate void SinalModMoeda(int valor);
	[Signal]
	public delegate void SinalModDiamante();
	
	//Controla as ações
	public Controle controle = new Controle();
	
	
	//Propriedades
	public int Vida{
		get => _vida;
		set{
			_vida = Math.Max(0,Math.Min(value, _vidaMax));
			EmitSignal(nameof(SinalModVida), _vida);
		
			//Emite sinal da morte
			if(_vida == 0) Morte();
		}
	}
	
	public int Mana{
		get => _mana;
		set{
			_mana = Math.Max(0,Math.Min(value, _manaMax));
			EmitSignal(nameof(SinalModMana), _mana);
		}
	}
	
	public int VidaMax{
		get => _vidaMax;
		set{
			//O minimo é 1
			if(value < 1) value = 1;
			_vidaMax = value;
			//Atualiza o valor da vida respeitando o novo limite
			if(_vida > _vidaMax) Vida = _vidaMax;

		}
	}

	public int ManaMax{
		get => _manaMax;
		set{
			//O minimo é 0
			if(value < 0) value = 0;
			_manaMax = value;
			//Atualiza o valor da mana respeitando o novo limite
			if(_mana > _manaMax) Mana = _manaMax;
		}
	}
	

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		base._Ready();
		AddToGroup("Vivo");
		
	}
	
	public override void _PhysicsProcess(float delta){
		_AtualizaControle();
		base._PhysicsProcess(delta);
	}
	
	//Funções para manipular a vida
	public void Dano(int valor = 1){
		Vida -= valor;
		
	}
	
	public void  AddVida(int valor = 1){
		Vida += valor;
	}
	
	//Funções para manipulacao da mana
	public void GastaMana(int valor = 1){
		_mana -= valor;
		
	}
	
	public void AddMana(int valor = 1){
		_mana -= valor;
		EmitSignal(nameof(SinalModMana), _mana);
	}
	
	//Função chamada quando não se tem mais vida
	public void Morte(){
		EmitSignal(nameof(SinalMorte));
	}
	
	//Função para atualizar o controle
	protected virtual void _AtualizaControle(){
		return;
	}
	
	//
	protected override void _AnimProx(){
		if(controle.esq){
			AnimFlip = true;
		}
		else if(controle.dir){
			AnimFlip = false;
		}
	} 
	

}
