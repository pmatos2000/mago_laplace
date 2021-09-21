using Godot;
using mago_laplace.Scripts.Cenas.Gestores.GestorControle;
using mago_laplace.Scripts.Cenas.Gestores.GestorMovimento;
using mago_laplace.Scripts.Constantes;
using mago_laplace.Scripts.Entidades;
using mago_laplace.Scripts.Interfaces;
using System.Collections.Generic;

namespace mago_laplace.Scripts.Inimigos
{
    public class CaranguejoLaranja : KinematicBody2D
    {
        private readonly IControler gestorControle = new InimigoSimplesControle(DirecaoMovimento.ESQUERDA);
        private readonly IGestorMovimento gestorMovimento = new BasicoGestorMovimento();
        private readonly DadosBase dadosBase = DadosBase.CaranguejoLaranja;

        private Vector2 aceleracao = new Vector2();
        private readonly List<Acao> listaDeAcao = new List<Acao>();

        public override void _Ready()
        {
            AddToGroup(Constantes.Constantes.Grupos.INIMIGO);

            var animacao = MetodosUteis.ObterNo<AnimatedSprite>(this, Constantes.Constantes.Caminhos.SPRITE_ANIMADO);
            animacao.Play();
        }

        public override void _PhysicsProcess(float delta)
        {
            var dadosMovimento = new DadosMovimento
            {
                Aceleracao = aceleracao,
                DadosBaseJogador = dadosBase,
                Comandos = gestorControle.ObterComandos(listaDeAcao),
                Sensor = new Sensor
                {
                    NoChao = IsOnFloor(),
                },
                DadosMundo = new DadosBaseMundo
                {
                    Gravidade = 15f,
                    AtritoComChao = 5f,
                }
            };
            AtualizarMovimento(dadosMovimento);
        }

        private void AtualizarMovimento(DadosMovimento dadosMovimento)
        {
            var novaAceleracao = gestorMovimento.ObterNovaAceleracao(dadosMovimento);
            aceleracao = MoveAndSlide(novaAceleracao, Constantes.Constantes.Sistema.DirParaCima);
        }
    }
}