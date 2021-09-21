using Godot;
using mago_laplace.Scripts.Interfaces;
using System;

namespace mago_laplace.Scripts.Cenas.Gestores.GestorMovimento
{
    public class BasicoGestorMovimento : IGestorMovimento
    {
        private int quantidadesPulosDados = 0;
        private bool travaDaAcaoPular = false;

        public Vector2 ObterNovaAceleracao(DadosMovimento dados)
        {
            var deltaX = AtualizarMovimentoEmX(dados);
            var deltaY = AtualizarMovimentoEmY(dados);
            return new Vector2(deltaX, deltaY);
        }

        private float AtualizarMovimentoEmX(DadosMovimento dados)
        {
            var deltaX = dados.Aceleracao.x;
            var aceleracaoMovimento = dados.DadosBaseJogador.AceleracaoMovimento;
            if (dados.Comandos.Esquerda) deltaX -= aceleracaoMovimento;
            if (dados.Comandos.Direita) deltaX += aceleracaoMovimento;
            if (dados.Sensor.NoChao)
            {
                var atritoComChao = dados.DadosMundo.AtritoComChao;
                if (deltaX > atritoComChao)
                {
                    deltaX -= atritoComChao;
                }
                else if (-deltaX > atritoComChao)
                {
                    deltaX += atritoComChao;
                }
                else
                {
                    deltaX = 0f;
                }
            }
            return MaxMin(deltaX, dados.DadosBaseJogador.AceleracaoMaximaX);
        }

        private float AtualizarMovimentoEmY(DadosMovimento dados)
        {
            var deltaY = dados.Aceleracao.y;
            var comandoX = dados.Comandos.X;
            var noCaho = dados.Sensor.NoChao;
            deltaY += dados.DadosMundo.Gravidade;

            if ((noCaho || dados.DadosBaseJogador.PermitirPularNoAr) && comandoX && quantidadesPulosDados < dados.DadosBaseJogador.QuantidadeMaximaPulo && !travaDaAcaoPular)
            {
                quantidadesPulosDados++;
                travaDaAcaoPular = true;
                deltaY = -dados.DadosBaseJogador.AlturaPulo;
            }
            else if (!comandoX && travaDaAcaoPular)
            {
                travaDaAcaoPular = false;
            }
            else if (noCaho)
            {
                quantidadesPulosDados = 0;
            }
            return MaxMin(deltaY, dados.DadosBaseJogador.AceleracaoMaximaY);
        }

        private float MaxMin(float valor, float referencia)
        {
            return Math.Max(-referencia, Math.Min(valor, referencia));
        }
    }
}