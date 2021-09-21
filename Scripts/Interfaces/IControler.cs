using Godot;
using mago_laplace.Scripts.Entidades;
using System;
using System.Collections.Generic;

namespace mago_laplace.Scripts.Interfaces
{
    public interface IControler
    {
        Controle ObterComandos(List<Acao> listaDeAcao = null);
    }
}