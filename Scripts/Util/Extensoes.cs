using Godot;
using System.Collections.Generic;
using System.Linq;

namespace mago_laplace.Scripts.Util
{
    public static class Extensoes
    {
        public static bool EhVazioOuNulo<T>(this List<T> dados) => dados == null || dados.Count == 0;
    }
}