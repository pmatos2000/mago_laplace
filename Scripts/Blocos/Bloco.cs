using Godot;
using System;

public class Bloco : StaticBody2D
{

	protected Sprite _sprite;
	protected AnimationPlayer _animPlayer;

	//Nomes das animações
	public const string ANIM_PARA_CIMA = "ParaCima";
	public const string ANIM_PARA_BAIXO = "ParaBaixo";


	public override void _Ready(){
		_Referencia();
		_Sinais();
	}

	
	//Salva as referencias
	protected virtual void _Referencia(){
		_sprite = _GetNode<Sprite>("Sprite");
		_animPlayer = _GetNode<AnimationPlayer>("AnimPlayerBlocos");
	}

	protected virtual void _Sinais(){
		_animPlayer.Connect("animation_finished", this, nameof(_FimAnimacaoAnimPlayer));
	}

	//Erro de falta de nó
	protected void _ErroFaltaNo(String nomeNo){
		GD.Print("Falta o ", nomeNo, this);
		GetTree().Quit();
	}
	
	//Retorna o No e verifica se ele existe
	protected T _GetNode<T>(string nome)  where T : class {
		T t = GetNode<T>(nome);
		if(t == null){
			_ErroFaltaNo(nome);
		}
		return t;
	}
		

	protected void _ExecutaAnim(string anim = ""){
		_animPlayer.Play(anim);
	}


	//Metodo para destruir o bloco
	protected void _Destroi(){
		Sprite img;
		
		//Numero de divições do bloco
		const int n = 4; 
		const int m = 4;
		
		//Dimensão
		Vector2 dim = new Vector2(40.0f/n, 40.0f/m);

		//Numero aleatorio
		Random rnd = new Random();

		Node pai = GetParent<Node>();
		MovGravidade movGravidade;

		//Time para eliminar os sprites
		Timer timer = new Timer();
		timer.WaitTime = 1f; //Tempo para emitir o sinal
		
		for(int i = 0; i < n; i++){
			for(int j = 0; j < m; j++){
				img = new Sprite();
				img.Texture = _sprite.Texture;
				img.Hframes = n;
				img.Vframes = m;
				img.Frame = i * m + j;
				img.Centered = false;
				img.GlobalPosition =  new Vector2(GlobalPosition.x + dim.x * i, GlobalPosition.y + dim.y * j);
				movGravidade = new MovGravidade();
				movGravidade.AddChild(img);
				movGravidade.Mov = new Vector2(rnd.Next(-100,100),rnd.Next(-200,-50)); //Movimento Inicial
				pai.AddChild(movGravidade);

				timer.Connect("timeout", movGravidade, "queue_free"); //Apaga automaticamente
				
			}
		}

		//Apaga o timer automaticamente
		timer.Connect("timeout", timer, "queue_free");
		pai.AddChild(timer);
		
		//Inicia o timer
		timer.Start();

		QueueFree();
	}

	//Trata o fim das animacoes
	protected virtual void _FimAnimacaoAnimPlayer(string nome){
		return;
	}


	
}
