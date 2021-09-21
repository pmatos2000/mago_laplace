using mago_laplace.Scripts.Constantes;
using mago_laplace.Scripts.Entidades;
using mago_laplace.Scripts.Interfaces;
using mago_laplace.Scripts.Util;
using System.Collections.Generic;

namespace mago_laplace.Scripts.Cenas.Gestores.GestorControle
{
    public class InimigoSimplesControle : IControler
    {
        private DirecaoMovimento direcaoAtual;

        public InimigoSimplesControle(DirecaoMovimento direacaoInicial)
        {
            direcaoAtual = direacaoInicial;
        }

        public Controle ObterComandos(List<Acao> listaDeAcao = null)
        {
            if (!listaDeAcao.EhVazioOuNulo())
            {
                var acao = listaDeAcao.Find(a => a.Id == IdAcao.MUDAR_DIRECAO);
                if (acao != null)
                {
                    if (direcaoAtual == DirecaoMovimento.ESQUERDA)
                    {
                        direcaoAtual = DirecaoMovimento.DIREITA;
                    }
                    else if (direcaoAtual == DirecaoMovimento.DIREITA)
                    {
                        direcaoAtual = DirecaoMovimento.ESQUERDA;
                    }
                }
            }

            return new Controle
            {
                Esquerda = (direcaoAtual == DirecaoMovimento.ESQUERDA),
                Direita = (direcaoAtual == DirecaoMovimento.DIREITA),
            };
        }
    }
}