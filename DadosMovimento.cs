using Godot;

public class DadosMovimento
{
	public Vector2 Aceleracao { get; set; }
	public DadosBase DadosBaseJogador { get; set; }
	public Controle Comandos { get; set; }
	public Sensor Sensor { get; set; }
	public DadosBaseMundo DadosMundo { get; set; }

	public DadosMovimento() { }
}
