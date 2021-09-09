using Godot;
using System;

public class DadosBase
{
	public IdDados Id { get; private set; }
	public string Nome { get; private set; }
	public float AceleracaoMaximaX { get; private set; }
	public float AceleracaoMaximaY { get; private set; }
	public float AlturaPulo { get; private set; }
	public int QuantidadeMaximaPulo {get; private set; }
	public float AceleracaoMovimento {get; private set; }

	public enum IdDados
	{
		MAGO_ESTRELA,
	} 

	public static readonly DadosBase MagoLaplaceEstrela = new DadosBase
	{
		Id = IdDados.MAGO_ESTRELA,
		Nome = "mago_estrela",
		AceleracaoMaximaX = 125f,
		AceleracaoMaximaY = 750f,
		AlturaPulo = 525f,
		QuantidadeMaximaPulo = 1,
		AceleracaoMovimento = 15f,
	};

	private DadosBase() { }


}
