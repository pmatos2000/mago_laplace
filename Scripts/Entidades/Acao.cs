using mago_laplace.Scripts.Constantes;
using System;

namespace mago_laplace.Scripts.Entidades
{
    public class Acao
    {
        public IdAcao Id { get; set; }
        public System.Object Dados { get; set; }

        public T ObterDados<T>()
        {
            return (T) Dados;
        }
    }
}