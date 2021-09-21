using Godot;
using mago_laplace.Scripts.Entidades;
using mago_laplace.Scripts.Interfaces;
using System;
using System.Collections.Generic;

namespace mago_laplace.Scripts.Cenas.Gestores.GestorControle
{
    public class JogadorControler : IControler
    {
        public JogadorControler() { }

        public Controle ObterComandos(List<Acao> listaDeAcao = null)
        {
            return new Controle
            {
                Esquerda = Input.IsActionPressed("ui_left"),
                Direita = Input.IsActionPressed("ui_right"),
                X = Input.IsActionJustPressed("ui_a"),
            };
        }

    }
}