using Godot;
using System;

public class Gerador : Node2D
{
	private String _caminhoCena = "";
	
	private PackedScene _cena;

	private static float DIST  = 480;
	private static float DIST_APAGA  = 640;
	
	private Node2D _ref = null;
	private Node2D _gerado = null;
	
	private bool _trava = true;
	
	public String CaminhoCena{
		set => _caminhoCena = value;
	}
	
	
	public override void _Ready(){
		_SetValoresPadrao();
		_Referencia();
		_Sinais();
	}
	
	//Pega a referencia dos objetos
	protected virtual void _Referencia(){
		//Pega a referencia do jogador
		Godot.Collections.Array vetor;
		vetor = GetTree().GetNodesInGroup("Jogador");
		if(vetor == null){
			_Erro("Jogador não encontrado", "_Ready()");
		}
		else{
			_ref = (Node2D) vetor[0];
		}
		
		//Carrega a cena
		_cena = (PackedScene) ResourceLoader.Load(_caminhoCena);
		if(_cena == null){
			_Erro("Cena não encontrada", "_Ready()");
		}
		
		//Remove o sprite
		Sprite sprite = GetNode<Sprite>("Sprite");
		if(sprite != null){
			sprite.Visible = false;
			sprite.QueueFree();
		}
	}
	
	//Realiza a conexões dos sinais
	protected virtual void _Sinais(){
		return;
	}
	
	//Altera os valores padroes
	protected virtual void _SetValoresPadrao(){
		return;
	}
	
	protected void _Erro(String msg, String nomeFunc = ""){
			GD.Print("ERRO: Classe: Gerador; Função: ", nomeFunc, "; Msg:", msg);
			GetTree().Quit();
	}
	
	private bool _VerDist(){
		return ((GlobalPosition - _ref.GlobalPosition).Length() < DIST);
	}
	
	private bool _VerDistApaga(){
		if(_gerado != null){
			return ((_gerado.GlobalPosition - _ref.GlobalPosition).Length() >  DIST_APAGA);
		}
		return false;
		
	}
	
	protected void _Gera(){
		_gerado = (Node2D) _cena.Instance();
		_GeradoConfig(_gerado, _ref);
		AddChild(_gerado);
		
	}
	
	protected void _Apaga(){
		RemoveChild(_gerado);
		_gerado = null;
		_trava = true;
		
	}
	
	public override void _PhysicsProcess(float delta){
		if(_gerado == null){
			bool verDist = _VerDist();
			if(verDist && _trava == false){
				_Gera();
			}
			else if(!verDist){
				_trava = false;
			}
		}
		else if(_VerDistApaga()){
			_Apaga();
		}
	}
	
	//Função chamada depois que foi gerado
	protected virtual void _GeradoConfig(Node2D gerado, Node2D refe){
		return;
	}
	
}
