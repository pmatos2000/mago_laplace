using Godot;
using mago_laplace.Scripts.Interfaces;
using System;

public class GestorSinaisFases : IGestorSinais
{
    public void ConectarSinais(Node noPai)
    {
        var jogador = MetodosUteis.ObterNo<Jogador>(noPai, "Principal/Jogador");
        var placar = MetodosUteis.ObterNo<Placar>(noPai, "Interface/Placar");

        ConectarSinaisJogador(jogador, placar);
    }

    private void ConectarSinaisJogador(Jogador jogador, Placar placar)
    {
        jogador.Connect(Jogador.SINAL_ATUALIZAR_QUANTIDADE_MOEDA, placar, nameof(placar.ModificarMoeda));
        jogador.Connect(Jogador.SINAL_MODIFICAR_STATUS_DIAMANTE, placar, nameof(placar.ModificarStatusDiamantes));
    }
}
