using Godot;
using System;

public class Diamante : Coletavel
{
	[Export]
	private Id id = Id.DIAMANTE_1;
	private Memoria _memLocal;

	public enum Id
    {
		DIAMANTE_1,
		DIAMANTE_2,
		DIAMANTE_3,
	}


	protected override void _Referencias(){
		base._Referencias();
		_memLocal = _GetNode<Memoria>("/root/MemLocal");
		
	}


	protected override void _SensorCorpoEntrou(Node corpo){
		if(corpo is Jogador jogador){
			jogador.AdicionarDiamanete(id);
			_ExecutaMusica(CentralAudio.ID.AudioDiamante);
			QueueFree();
		}
	}
}
