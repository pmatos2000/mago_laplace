using Godot;
using System;

public class JogadorGestorMovimento : IGestorMovimento
{
	const float ATRITO_COM_CHAO = 5;
	const float GRAVIDADE = 15f;
	private int quantidadesPulosDados = 0;
	private bool travaDaAcaoPular = false;
	
	public Vector2 ObterNovaAceleracao(DadosMovimento dadosMovimento)
	{
		var deltaX = AtualizarMovimentoEmX(dadosMovimento);
		var deltaY = AtualizarMovimentoEmY(dadosMovimento);
		return new Vector2(deltaX, deltaY);
	}

	private float AtualizarMovimentoEmX (DadosMovimento dadosMovimento)
	{
		var deltaX = dadosMovimento.Aceleracao.x;
		var aceleracaoMovimento = dadosMovimento.DadosBaseJogador.AceleracaoMovimento;
		if(dadosMovimento.Comandos.Esquerda) deltaX -= aceleracaoMovimento;
		if(dadosMovimento.Comandos.Direita) deltaX += aceleracaoMovimento;
		if (dadosMovimento.Sensor.NoChao)
		{
			var atritoComChao = dadosMovimento.DadosMundo.AtritoComChao;
			if(deltaX > atritoComChao)
			{
				deltaX -= atritoComChao;
			}
			else if(-deltaX > atritoComChao)
			{
				deltaX += atritoComChao;
			}
			else{
				deltaX = 0f;
			}
		}
		return  MaxMin(deltaX, dadosMovimento.DadosBaseJogador.AceleracaoMaximaX);
	}

	private float AtualizarMovimentoEmY (DadosMovimento dadosMovimento)
	{
		var deltaY = dadosMovimento.Aceleracao.y;
		var comandoX = dadosMovimento.Comandos.X;
		var noCaho = dadosMovimento.Sensor.NoChao;
		deltaY += dadosMovimento.DadosMundo.Gravidade;

		if((noCaho || dadosMovimento.DadosBaseJogador.PermitirPularNoAr) && comandoX && quantidadesPulosDados < dadosMovimento.DadosBaseJogador.QuantidadeMaximaPulo && !travaDaAcaoPular)
		{
			quantidadesPulosDados++;
			travaDaAcaoPular = true;
			deltaY = -dadosMovimento.DadosBaseJogador.AlturaPulo;
		}
		else if(!comandoX && travaDaAcaoPular)
		{
			travaDaAcaoPular = false;
		}
		else if(noCaho)
		{
			quantidadesPulosDados = 0;
		}
		return MaxMin(deltaY, dadosMovimento.DadosBaseJogador.AceleracaoMaximaY);
	}

	private float MaxMin(float valor, float referencia)
	{
		return  Math.Max(-referencia,Math.Min(valor, referencia));
	}
}
