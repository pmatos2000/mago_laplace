using Godot;
using System;

public class MoedaInsta : Node2D
{
	private static CentralAudio centralAudio;
	public override void _Ready(){
		GetNode<AnimationPlayer>("AnimationPlayer").Play("AddJogador");
		if(centralAudio == null){
			centralAudio = GetNode<CentralAudio>("/root/CentralAudio");
		}
		centralAudio.executa(CentralAudio.ID.AudioMoeda);
		_AddJogador();
	}

	private void _AddJogador(){
		Godot.Collections.Array array = GetTree().GetNodesInGroup("Jogador");
		if(array != null){
			Vivo vivo = (Vivo) array[0];
			vivo.AddMoeda();
		}
	}
}
