using Godot;
using System;

public class Level : Node
{
	private Jogador _jogador;
	private Relogio _relogio;
	private Memoria _memLocal;
	private Memoria _memGlobal;
	private Placar _placar;
	private MsgTela _msgTela;
	
	private bool _reniciaFase = false;
	/*
	
	[Export]
	private int tempoMax = 180;
	
	
	private float dt = 0; // Tempo que já passou
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready(){
		_Referencias();
		_Sinais();
		_Placar();
		_Jogador();
		_Relogio();
	}
	
	public override void _Process(float delta){
		if(_reniciaFase){
			ReniciaFase();
		}
	}

	//Pega as referencias do objetos
	protected void _Erro(String msg, String nomeFunc = ""){
		GD.Print("ERRO: Classe: Level; Função: ", nomeFunc, "; Msg:", msg);
		GetTree().Quit();
	}

	//Referencias
	private void _Referencias(){
		_jogador = GetNode<Jogador>("Principal/Jogador");
		if(_jogador == null){
			_Erro("Jogador não encontrado", "_Referencias");
		}
		_memLocal = GetNode<Memoria>("/root/MemLocal");
		if(_memLocal == null){
			_Erro("MemLocal não encontrado", "_Referencias");
		}
		_memGlobal = GetNode<Memoria>("/root/MemGlobal");
		if(_memGlobal == null){
			_Erro("MemGlobal não encontrado", "_Referencias");
		}
		_placar = GetNode<Placar>("Interface/Placar");
		if(_placar == null){
			_Erro("Placar não encontrado", "_Referencias");
		}
		_relogio = GetNode<Relogio>("Relogio");
		if(_relogio == null){
			_Erro("Relogio não encontrado", "_Referencias");
		}
		_msgTela = GetNode<MsgTela>("Interface/Tela/MsgTela");
		if(_msgTela == null){
			_Erro("MsgTela não encontrado", "_Referencias");
		}
	}
	
	//Conectas os sinais
	private void _Sinais(){
		_jogador.Connect("SinalMorte", this, nameof(_JogadorMorreu));
		_relogio.Connect("SinalRelogioFim", this, nameof(_FimDoTempo));
	}
	
	// Configura o placar
	private void _Placar(){
		_placar.Jogador = _jogador;
		_placar.Relogio = _relogio;
	}

	// Configura o jogador
	private void _Jogador(){
		_jogador.Vida = _memGlobal.GetInt("Jogador_Vida", 2);
		_jogador.Mana = _memGlobal.GetInt("Jogador_Mana", 4);
	}
	
	// Configura o relogio
	private void _Relogio(){
		_relogio.TempoMax = tempoMax;
		_relogio.Inicia();
	}
	
	//Jogador Morreu
	private void _JogadorMorreu(){
		_msgTela.AtivaQuadro("Você perdeu!");
		_reniciaFase = true;
	}
	
	//Fim do tempo
	private void _FimDoTempo(){
		_msgTela.AtivaQuadro("O tempo acabou!");
		_reniciaFase = true;
	}
	
	//Renicia a fase
	public void ReniciaFase(){
		_memLocal.Limpa();
		GetTree().ReloadCurrentScene();
	}
	*/
}
