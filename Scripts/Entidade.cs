using Godot;
using System;

public class Entidade : KinematicBody2D{
	
	// Constantes
	static private Vector2 _dirParaCima = new Vector2(0,-1);
	
	// Fisica
	private bool _fisica = true;
	private CollisionShape2D _colisaoFisica;
	private float _gravidade = 15;
	private float _atrito = 10;
	private float _aceDesl = 0; //Aceleração de deslocamento
	private Vector2 _mov = new Vector2();
	private Vector2 _movMax = new Vector2(125,500);

	// Animações
	protected string _animAtual = "";
	protected string _animProx = "";
	protected AnimatedSprite _anim;
	
	//Sensores
	private Area2D _sensor;
	
	
	//Propriedades
	public bool Fisica{
		get => _fisica;
		set{
			_fisica = value;
			_colisaoFisica.Disabled = !value;
		}
	}
	
	public float Gravidade{
		get => _gravidade;
		set => _gravidade = value;
	}


	public float Atrito{
		get => _atrito;
		set => _gravidade = value;
	}
	
	public float AceDesl{
		get => _aceDesl;
		set => _aceDesl = value;
	}
	
	public String AnimProx{
		set => _animProx = value;
	}
	
	public bool AnimFlip{
		set{
			_anim.FlipH = value;
		}
	}
	
	public Vector2 Mov{
		get => _mov;
		set{
				_mov.x = Math.Max(-_movMax.x,Math.Min(value.x, _movMax.x));
				_mov.y = Math.Max(-_movMax.y,Math.Min(value.y, _movMax.y));
			}
	}
	
	public Vector2 MovMax{
		get => _movMax;
		set => _movMax = value;
	}

	// Executa assim que entrar na arvore de nodes
	public override void _Ready(){
		AddToGroup("Entidade");
		_Referencias();
		_anim.Playing = true;
		_Sinais();
	}
	
	//Erro de falta de nó
	protected void _ErroFaltaNo(String nomeNo){
		GD.Print("Falta o ", nomeNo, this);
		GetTree().Quit();
	}
	
	//Pega todas as referencias
	protected void _Referencias(){
		_anim = GetNode<AnimatedSprite>("Anim");
		if(_anim == null){
			_ErroFaltaNo("Anim");
		}
		_colisaoFisica = GetNode<CollisionShape2D>("ColisaoFisica");
		if(_colisaoFisica == null){
			_ErroFaltaNo("ColisaoFisica");
		}
		_sensor = GetNode<Area2D>("Sensor");
		if(_sensor == null){
			_ErroFaltaNo("Sensor");
		}
	} 
	
	//Realiza a conexão dos sinais
	protected void _Sinais(){
		_sensor.Connect("body_entered", this, nameof(_SensorCorpoEntrou));
	}
	
	// Função que vai ser executado ao um corpo fisico reagir com o sensor principal
	protected void _SensorCorpoEntrou(){
		return;
	}
	
	
	//Executa em tempo constante
	public override void _PhysicsProcess(float delta){
		if(_fisica){
			_Movimento();
			_RealizaMovimento();
		}
		_AnimProx();
		_AnimExecuta();
	}

	protected virtual void _Movimento(){
		_mov.y += _gravidade;
	}
	
	private void _RealizaMovimento(){
		_mov = MoveAndSlide(_mov, _dirParaCima);
	}
	
	
	//Determina a proxima animação
	protected virtual void _AnimProx(){
		return;
	} 
	

	//Executa a proxima animação
	private void _AnimExecuta(){
		if(!_animAtual.Equals(_animProx)){
			_anim.Play(_animProx);
			_animAtual = _animProx;
		}
	} 

}
