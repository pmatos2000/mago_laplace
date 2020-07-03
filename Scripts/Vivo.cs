using Godot;
using System;

public class Vivo : Entidade
{
	//Dados vida
	private int _vida = 1;
	private int _mana = 0;
	private int _vidaMax = 1;
	private int _manaMax = 0;
	private int _moeda = 0;
	private int _moedaAcc = 0;
	private bool _indestrutivel = false;
		
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
	
	//Controla animações que trabalham com propriedades
	private AnimationPlayer _animPlayer;
	
	//Nome das animacoes
	protected static string ANIM_INDESTRUTIVEL = "Indestrutivel";
	protected static string ANIM_DANO = "Dano";
	protected static string ANIM_MORTE = "Morte";
	protected static string ANIM_MANA = "Mana";
	protected static string ANIM_VIDA = "Vida";
	
	
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
	
	public int Moeda{
		get => _moeda;
		set{
			_moeda = value;
			if(_moeda < 0) _moeda = 0;
			EmitSignal(nameof(SinalModMoeda),_moeda);
		}
	}
	
	private int _MoedaAcc{
		get => _moedaAcc;
		set{
			_moedaAcc = value;
			if(_moedaAcc < 0) _moedaAcc = 0;
			if(_moedaAcc >= 25){
				AddVida();
				_moedaAcc -= 25;
			}
			
		}
	}
	
	public bool Indestrutivel{
		get => _indestrutivel;
		set{
			_indestrutivel = value;
			_ExecAnimPlayer(ANIM_INDESTRUTIVEL);
		}
	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready(){
		base._Ready();
		AddToGroup("Vivo");
		
	}
	
	protected override void _Referencias(){
		base._Referencias();
		_animPlayer = GetNode<AnimationPlayer>("AnimPlayerBase");
	}
	
	protected override void _Sinais(){
		base._Sinais();
		_animPlayer.Connect("animation_finished", this, nameof(_FimAnimacaoAnimPlayer));
	}
	
	public override void _PhysicsProcess(float delta){
		_AtualizaControle();
		base._PhysicsProcess(delta);
	}
	
	//Funções para manipular a vida
	public virtual void Dano(int valor = 1){
		if(!_indestrutivel) Vida -= valor;
	}
	
	public void  AddVida(int valor = 1){
		Vida += valor;
		_ExecAnimPlayer(ANIM_VIDA);
	}
	
	//Funções para manipulacao da mana
	public void GastaMana(int valor = 1){
		_mana -= valor;
		
	}
	
	public void AddMana(int valor = 1){
		_mana += valor;
		EmitSignal(nameof(SinalModMana), _mana);
	}
	
	//Função chamada quando não se tem mais vida
	public virtual void Morte(){
		Fisica = false;
		_ExecAnimPlayer(ANIM_MORTE);
		EmitSignal(nameof(SinalMorte));
	}
	
	//Função para atualizar o controle
	protected virtual void _AtualizaControle(){
		return;
	}
	
	//Controla a animação
	protected override void _AnimProx(){
		if(controle.esq){
			AnimFlip = true;
		}
		else if(controle.dir){
			AnimFlip = false;
		}
	} 
	
	public void AddMoeda(int valor = 1){
		Moeda += 1;
		_MoedaAcc += 1;
	}
	
	//Controla a animação do AnimPlayer
	protected void _ExecAnimPlayer(string nome){
		_animPlayer.Play(nome);
	}
	
	//Chama quando a animacao do Anim Player chegar ao fim
	private void _FimAnimacaoAnimPlayer(string nome){
		if(nome.Equals("Indestrutivel")){
			_indestrutivel = false;
		}
		else if(nome.Equals(ANIM_MORTE)){
			QueueFree();
		}
	}
	
}
