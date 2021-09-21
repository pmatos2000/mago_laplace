using Godot;
using System;

namespace mago_laplace.Scripts.Constantes
{
    public class DadosBase
    {
        public IdDadosBase Id { get; private set; }
        public string Nome { get; private set; }
        public float AceleracaoMaximaX { get; private set; }
        public float AceleracaoMaximaY { get; private set; }
        public float AlturaPulo { get; private set; }
        public int QuantidadeMaximaPulo { get; private set; }
        public float AceleracaoMovimento { get; private set; }
        public bool PermitirPularNoAr { get; private set; }
        public int QuantidadeMaximaCoracao { get; private set; }

        public static readonly DadosBase MagoLaplaceEstrela = new DadosBase
        {
            Id = IdDadosBase.MAGO_ESTRELA,
            Nome = "mago_estrela",
            AceleracaoMaximaX = 125f,
            AceleracaoMaximaY = 750f,
            AlturaPulo = 525f,
            QuantidadeMaximaPulo = 2,
            AceleracaoMovimento = 15f,
            PermitirPularNoAr = true,
            QuantidadeMaximaCoracao = 4,
        };

        public static readonly DadosBase CaranguejoLaranja = new DadosBase
        {
            Id = IdDadosBase.CARANGUEJO_LARANJA,
            Nome = "caranguejo_laranja",
            AceleracaoMaximaX = 125f,
            AceleracaoMaximaY = 750f,
            AlturaPulo = 525f,
            QuantidadeMaximaPulo = 1,
            AceleracaoMovimento = 15f,
            PermitirPularNoAr = false,
            QuantidadeMaximaCoracao = 4,
        };

        private DadosBase() { }


    }
}