using Godot;
using System;

public class Relogio : Node
{
	[Signal]
	private delegate void SinalAtualizarRelogio(int valor);
	public static readonly string SINAL_ATUALIZAR_RELOGIO = nameof(SinalAtualizarRelogio);

	[Signal]
	private delegate void SinalRelogioFim();
	public static readonly string SINAL_RELOGIO_FIM = nameof(SinalRelogioFim);

	public void SetTempoMax(float tempoMaximo)
    {
		if (tempoMaximo > 599)
		{
			tempoMaximo = 599;
		}
		else if (tempoMaximo < 0)
		{
			tempoMaximo = 0;
		}
		this.tempoMax = tempoMaximo;
    }

	private float tempoTotal = 0;
	private bool ativo = false;
	private int difAntes = 0;
    private float tempoMax;

    public override void _Process(float delta){
		if (ativo)
		{
			tempoTotal += delta;
			var dif = Math.Max((int) Math.Round(tempoMax - tempoTotal), 0);
			if(difAntes != dif)
			{
				difAntes = dif;
				EmitSignal(SINAL_ATUALIZAR_RELOGIO, dif);
			}
			if (dif == 0)
			{
				EmitSignal(SINAL_RELOGIO_FIM);
				ativo = false;
			}
		}
	}

    public void Ativar()
    {
		ativo = true;
    }
}
