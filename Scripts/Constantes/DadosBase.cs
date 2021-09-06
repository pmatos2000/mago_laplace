using Godot;
using System;

public class DadosBase
{
	public string Nome { get; private set; }
	public float AceleracaoMaximaX { get; private set; }
	public float AceleracaoMaximaY { get; private set; }
	public float AlturaPulo { get; private set; }
	public int QuantidadeMaximaPulo {get; private set; }
	public float AceleracaoMovimento {get; private set; }

	private DadosBase() { }

	public static readonly DadosBase MagoLaplaceEstrela = new DadosBase
	{
		Nome = "mago_estrela",
		AceleracaoMaximaX = 125f,
		AceleracaoMaximaY = 750f,
		AlturaPulo = 475f,
		QuantidadeMaximaPulo = 2,
		AceleracaoMovimento = 15f,
	};


}
