using Godot;
using System;

public class Placar : CanvasLayer
{
	
	private PlacarVida _placarVida;
	private PlacarMana _placarMana;
	private PlacarRelogio placarRelogio;
	private PlacarDiamante placarDiamante;
	private PlacarMoeda placarMoeda;
	
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

		placarRelogio = GetNode<PlacarRelogio>("Relogio");
		placarDiamante = GetNode<PlacarDiamante>("Diamante");
		placarMoeda = GetNode<PlacarMoeda>("Moeda");
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
		placarRelogio.SetValor(valor);
	}
	
	public void ModificarMoeda(uint valor){
		placarMoeda.Valor = valor;
	}

	public void ModificarStatusDiamantes(Diamante.Id idDiamante)
	{
		placarDiamante.ModificarStatusDiamantes(idDiamante);
	}
}
