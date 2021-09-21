using Godot;
using System;

namespace mago_laplace.Scripts.Interfaces
{
    public interface IGestorMovimento
    {
        Vector2 ObterNovaAceleracao(DadosMovimento dados);
    }
}