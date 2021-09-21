using Godot;
using System;

namespace mago_laplace.Scripts.Constantes
{
    public static class Constantes
    {
        public static class Mensagem
        {
            public static readonly string ERRO_FALTA_NO = "Falta o nó {0}";
        }

        public static class Grupos
        {
            public static readonly string JOGADOR = "Jogador";
            public static readonly string MOEDA = "Moeda";
            public static readonly string COLETAVEL = "Coletavel";
            public static readonly string INIMIGO = "Inimigo";
        }

        public static class SinaisGodot
        {
            public static readonly string SENSOR_CORPO_ENTROU = "body_entered";
        }

        public static class Caminhos
        {
            public static readonly string CENTRAL_AUDIO = "/root/CentralAudio";
            public static readonly string SPRITE_ANIMADO = "Anim";

        }

        public static class Sistema
        {
            public static readonly ushort LARGURA_TELA = 853;
            public static readonly ushort ALTURA_TELA = 480;
            public static readonly Vector2 DirParaCima = new Vector2(0, -1);
        }
    }
}