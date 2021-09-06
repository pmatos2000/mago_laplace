using Godot;
using System;

public class JogadorGestorAnimacao : IGestorAnimacao
{
	private string animacaoAtual;
	public string ObterNovaAnimacao(DadosMovimento dadosMovimento)
	{
		var nome = dadosMovimento.DadosBaseJogador.Nome;
		var proximaAnimacao = "";
		if (!dadosMovimento.Sensor.NoChao)
		{
			proximaAnimacao = $"{nome}_pulando";
		}
		else if (dadosMovimento.Comandos.Direita || dadosMovimento.Comandos.Esquerda)
		{
			proximaAnimacao = $"{nome}_andando";
		}
		else
		{
			proximaAnimacao = $"{nome}_parado";
		}

		if (proximaAnimacao == animacaoAtual) return null;
		animacaoAtual = proximaAnimacao;
		return proximaAnimacao;
	}
}
