using Godot;
using System;

public class Constantes
{
    public static Vector2 DirParaCima = new Vector2(0, -1);

    public static class Mensagem
    {
        public static readonly string ERRO_FALTA_NO = "Falta o nó {0}";
    }

    public static class Grupos
    {
        public static readonly string JOGADOR = "Jogador";
        public static readonly string MOEDA = "Moeda";
        public static readonly string COLETAVEL = "Coletavel";
    }

    public static class SinaisGodot
    {
        public static readonly string SENSOR_CORPO_ENTROU = "body_entered";
    }

    public static class Caminhos
    {
        public static readonly string CENTRAL_AUDIO = "/root/CentralAudio";

    }
}
