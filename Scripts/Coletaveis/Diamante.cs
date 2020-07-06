using Godot;
using System;

public class Diamante : Coletavel
{
	private int id;
	private Memoria _memLocal;

	
	public override void _Ready(){
		base._Ready();
		id = _memLocal.GetInt("id_diamante");
		if(id > 2){ //No maximo so vão ter 3 diamantes
			QueueFree();
			return;
		}
		_memLocal.Add("id_diamante", id + 1);

	}

	protected override void _Referencias(){
		base._Referencias();
		_memLocal = _GetNode<Memoria>("/root/MemLocal");
		
	}


	protected override void _SensorCorpoEntrou(Node corpo){
		if(corpo is Jogador){
			Jogador jogador = (Jogador) corpo;
			_memLocal.Add("Diamante_" + id, true);
			jogador.EmitSignal("SinalModDiamante");
			_ExecutaMusica(CentralAudio.ID.AudioDiamante);
			QueueFree();
		}
	}
}
