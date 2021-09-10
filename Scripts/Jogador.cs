using Godot;
using System;

public class Jogador : KinematicBody2D, IControlavel
{
	private IControler controler;
	private IGestorMovimento gestorMovimento;
	private IGestorAnimacao gestorAnimacao;
	
	private DadosBase dadosBase;
	private AnimatedSprite spriteAnimado;
	private Vector2 aceleracao = new Vector2();


	public override void _Ready(){
		AddToGroup("Jogador");
		Inicializar();
		Referencias();
	}

	public override void _PhysicsProcess(float delta){
		var dadosMovimento = new DadosMovimento
		{
			Aceleracao = aceleracao,
			DadosBaseJogador = dadosBase,
			Sensor = ObterSensor(),
			Comandos = controler.ObterComandos(null),
			DadosMundo = new DadosBaseMundo
			{
				Gravidade = 15f,
				AtritoComChao = 5f, 
			}
		};
		AtualizarMovimento(dadosMovimento);
		AtualizarAnimacao(dadosMovimento);
	}

	public void InstalarControler(IControler controler)
	{
		this.controler = controler;
	}

	private Sensor ObterSensor()
	{
		return new Sensor
		{
			NoChao = IsOnFloor(),
		};
	}

	private void AtualizarMovimento(DadosMovimento dadosMovimento)
	{
		var novaAceleracao = gestorMovimento.ObterNovaAceleracao(dadosMovimento);
		aceleracao = MoveAndSlide(novaAceleracao, Constantes.DirParaCima);
	}

	public void Inicializar()
	{
		InstalarControler(new JogadorControler());
		gestorMovimento = new JogadorGestorMovimento();
		gestorAnimacao = new JogadorGestorAnimacao();
		dadosBase = DadosBase.MagoLaplaceEstrela;
	}

	private void Referencias()
	{
		spriteAnimado = MetodosUteis.ObterNo<AnimatedSprite>(this, "Anim");
	}

	
	private void AtualizarAnimacao(DadosMovimento dadosMovimento)
	{
		if (dadosMovimento.Comandos.Direita || dadosMovimento.Comandos.Esquerda)
		{
			spriteAnimado.FlipH = (dadosMovimento.Comandos.Esquerda) ? true : false;
		}
		var novaAnimacao = gestorAnimacao.ObterNovaAnimacao(dadosMovimento);
		if (novaAnimacao != null) spriteAnimado.Play(novaAnimacao);
	}


/*
	
	private bool _pulando = false;
	
	private Modo _modo;
	
	private const int movPulo = -475;
	
	//Sensores
	private Area2D _sensorPe;
	private Area2D _sensorBlocosPulo;
	
	
	private bool _forcaPulo = false;
	
	
	public void SetValorPadrao(){
		AceDesl = 15;
		MovMax = new Vector2(150, 500);
		VidaMax = 4;
		ManaMax = 4;
		_modo =  Modo.Estrela;
	}

	private IControle controle;

	public void InstalarControle(IControle controle){
		this.controle = controle;
	}

	public void Atualizar(){
		
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
		controle.a = Input.IsActionJustPressed("ui_a");
		controle.noChao = IsOnFloor();
	}
		
	//Movimento do Jogador
	protected override void _Movimento(){
		Vector2 mov = Mov;

		if(_forcaPulo){
			_forcaPulo = false;
			mov.y = movPulo;
			_pulando = true;
			Mov = mov;
			_ExecutaMusica(CentralAudio.ID.AudioPulo);
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
				_pulando = true;
				_ExecutaMusica(CentralAudio.ID.AudioPulo);
			}
			else{
				_pulando = false;
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
		if(_pulando){
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
		_sensorPe = _GetNode<Area2D>("SensorPe");
		_sensorBlocosPulo = _GetNode<Area2D>("SensorBlocosPulo");
	}
	
	protected override void _Sinais(){
		base._Sinais();
		_sensorPe.Connect("body_entered", this, nameof(_SensorPeCorpoEntrou));
		_sensorPe.Connect("body_exited", this, nameof(_SensorPeCorpoSaiu));
		_sensorBlocosPulo.Connect("body_exited", this, nameof(_SensorBlocosPuloEntrou));
	}
	
	private void _SensorPeCorpoEntrou(Node corpo){
		if(corpo is Inimigo){
			Inimigo inimigo = (Inimigo) corpo;
			inimigo.Fisica = false;
			inimigo.Dano();
			_forcaPulo = true;
		}
	}

	private void _SensorBlocosPuloEntrou(Node corpo){
		if(corpo is BlocoInterativo){
			BlocoInterativo bloco = (BlocoInterativo) corpo;
			if(_pulando){
				bloco.Executa();
			}
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
		_ExecutaMusica(CentralAudio.ID.AudioMorte);
		Fisica = false;
	}
	
	public override void Dano(int valor = 1){
		base.Dano(valor);
		Indestrutivel = true;
	}
	*/
}
