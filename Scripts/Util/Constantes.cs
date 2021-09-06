using Godot;
using System;

public class Constantes
{
    public static Vector2 DirParaCima = new Vector2(0, -1);

    public class Mensagem
    {
        public static readonly string ERRO_FALTA_NO = "Falta o nó {0}";
    }

    public class Sinais
    {
        [Signal]
        private delegate void AtualizarQuantidadeMorte(int valor);
        public static readonly string ATUALIZAR_QUANTIDADE_PULOS = nameof(AtualizarQuantidadeMorte);
    }
}
