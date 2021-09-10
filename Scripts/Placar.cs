using Godot;
using System;

public class Placar : CanvasLayer
{
	
	private PlacarVida _placarVida;
	private PlacarMana _placarMana;
	private PlacarRelogio _placarRelogio;
	private PlacarDiamante _placarDiamante;
	private PlacarMoeda _placarMoeda;
	
	private Jogador _jogador;
	private Relogio _relogio;
	

	public Relogio Relogio{
		set{
			_relogio = value;
			_SinaisRelogio();
		}
	}
	
	public override void _Ready(){
		AtualizarReferencia();

	}
	
	//Salva as referencias
	private void AtualizarReferencia(){
		_placarVida = GetNode<PlacarVida>("Vida");
		_placarMana = GetNode<PlacarMana>("Mana");
		_placarRelogio = GetNode<PlacarRelogio>("Relogio");
		_placarDiamante = GetNode<PlacarDiamante>("Diamante");
		_placarMoeda = GetNode<PlacarMoeda>("Moeda");
	}
	
	
	//Liga os sinais do relogio
	private void _SinaisRelogio(){
		_relogio.Connect("SinalModRelogio", this, nameof(SetRelogio));
	}
	
	protected void _Erro(String msg, String nomeFunc = ""){
		GD.Print("ERRO: Classe: Placar; Função: ", nomeFunc, "; Msg:", msg);
		GetTree().Quit();
	}
	
	public void SetVida(int valor){
		_placarVida.SetValor(valor);
	}
	
	public void SetMana(int valor){
		_placarMana.SetValor(valor);
	}

	public void SetRelogio(int valor){
		_placarRelogio.SetValor(valor);
	}
	
	public void ModificarMoeda(uint valor){
		GD.Print(valor);
		_placarMoeda.Valor = valor;
	}

	public void AtualizaDiamante(){
		_placarDiamante.Atualiza();
	}
}
