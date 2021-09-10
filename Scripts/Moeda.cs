using Godot;
using System;

public class Moeda : Node2D
{
	private Area2D sensor;

	public override void _Ready()
	{
		AdicionarEmGrupos();
		Referencias();
		Sinais();
	}


	private void AdicionarEmGrupos()
    {
		AddToGroup(Constantes.Grupos.MOEDA);
		AddToGroup(Constantes.Grupos.COLETAVEL);
	}

	private void Referencias()
    {
		sensor = MetodosUteis.ObterNo<Area2D>(this, "Sensor");
	}

	private void Sinais()
    {
		sensor.Connect(Constantes.SinaisGodot.SENSOR_CORPO_ENTROU, this, nameof(SensorCorpoEntrou));
    }

	private void SensorCorpoEntrou(Node corpo)
    {
		if (corpo is Jogador jogador)
        {
			ExecutarAcaoJogador(jogador);
		}
    }

	private void ExecutarAcaoJogador(Jogador jogador)
    {
		jogador.QuantidadeMoedas += 1;
		var centralAudio = MetodosUteis.ObterCentralAudio(this);
		centralAudio.ExecutarAudio(CentralAudio.ID.AudioMoeda);
		QueueFree();
	}
}
