using Godot;
using System;

public class Jogador : Vivo
{
	public enum Modo{
		Estrela,
		FOGO,
	}
	
	public bool pulando = false;
	
	private Modo _modo;
	
	private const int movPulo = -475;
	
	private Area2D _sensorPe;
	private AnimationPlayer _animPlayer;
	
	private bool _forcaPulo = false;
	
	
	public override void SetValorPadrao(){
		AceDesl = 15;
		MovMax = new Vector2(125,500);
		VidaMax = 4;
		ManaMax = 4;
		_modo =  Modo.Estrela;
	}
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready(){
		base._Ready();
		AddToGroup("Jogador");
	}
	
	//Atualiza o estado do controle
	protected override void _AtualizaControle(){
		controle.esq = Input.IsActionPressed("ui_left");
		controle.dir = Input.IsActionPressed("ui_right");
		controle.a = Input.IsActionPressed("ui_a");
		controle.noChao = IsOnFloor();
	}
		
	//Movimento do Jogador
	protected override void _Movimento(){
		Vector2 mov = Mov;
		
		if(_forcaPulo){
			_forcaPulo = false;
			mov.y = movPulo;
			pulando = true;
			Mov = mov;
			return;
		}
		
		//Gravidade
		mov.y += Gravidade;
		
		//Controle
		if(controle.dir){
			mov.x += (AceDesl - Atrito);
		}
		else if(controle.esq){
			mov.x -= (AceDesl - Atrito);
		}
		else if(controle.noChao){
			if(mov.x > Atrito){
				mov.x -= Atrito;
			}
			else if(mov.x < -Atrito){
				mov.x += Atrito;
			}
			else{
				mov.x = 0;
			}
		}
		else{
			mov.x = 0;
		}		
		if(controle.noChao){
			if(controle.a){
				mov.y = movPulo;
				pulando = true;
			}
			else{
				pulando = false;
			}
		}
		
		//Atualiza o vetor mov
		Mov = mov;
	}
	
	private string _GetStrModo(){
		return Enum.GetName(typeof(Modo), _modo);
	}
	
	protected override void _AnimProx(){
		base._AnimProx();
		if(pulando){
			AnimProx = _GetStrModo() + "_Pulando";
		}
		else if (controle.esq || controle.dir){
			AnimProx = _GetStrModo() + "_Andando";
		}
		else{
			AnimProx = _GetStrModo() + "_Parado";
		}
	}
	
	protected override void _Referencias(){
		base._Referencias();
		_sensorPe = GetNode<Area2D>("SensorPe");
		_animPlayer = GetNode<AnimationPlayer>("AnimPlayer");
	}
	
	protected override void _Sinais(){
		base._Sinais();
		_sensorPe.Connect("body_entered", this, nameof(_SensorPeCorpoEntrou));
		_sensorPe.Connect("body_exited", this, nameof(_SensorPeCorpoSaiu));
		_animPlayer.Connect("animation_finished", this, nameof(_FimAnimacaoAnimPlayer));
	}
	
	private void _SensorPeCorpoEntrou(Node corpo){
		if(corpo is Inimigo){
			Inimigo inimigo = (Inimigo) corpo;
			inimigo.Fisica = false;
			inimigo.Dano();
			_forcaPulo = true;
		}
	}
	
	private void _SensorPeCorpoSaiu(Node corpo){
		if(corpo is Inimigo){
			Inimigo inimigo = (Inimigo) corpo;
			inimigo.Fisica = true;
		}
	}
	
	//Sobreescreve o metodo para evitar pagar da cena
	public override void Morte(){
		EmitSignal(nameof(SinalMorte));
		Fisica = false;
	}
	
	public override void Dano(int valor = 1){
		base.Dano(valor);
		Indestrutivel = true;
		_animPlayer.Play("Indestrutivel");
	}
	
	//Chama quando a animacao do Anim Player chegar ao fim
	private void _FimAnimacaoAnimPlayer(string nome){
		if(nome.Equals("Indestrutivel")){
			Indestrutivel = false;
		}
	}
}
