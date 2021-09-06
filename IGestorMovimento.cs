using Godot;
using System;

public interface IGestorMovimento
{
	Vector2 ObterNovaAceleracao(DadosMovimento dados);
}
