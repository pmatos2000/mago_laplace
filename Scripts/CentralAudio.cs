using Godot;
using System;
using System.Collections.Generic;

public class CentralAudio : Node
{
	public enum ID{
		AudioMoeda,
		AudioVida,
		AudioPulo,
		AudioMorte,
		AudioDano,
	}
	
	private Dictionary<ID, AudioStreamPlayer> _dicAudio;
	
	public override void _Ready(){
		_dicAudio = new Dictionary<ID, AudioStreamPlayer>();
		
		AudioStreamPlayer audioStream;
		string nome; //O nome vai ser o mesmo do enum 
		
		foreach(int id in Enum.GetValues(typeof(ID))){
			nome = Enum.GetName(typeof(ID), id);
			audioStream = _GetNode<AudioStreamPlayer>(nome);
			_dicAudio.Add((ID)id, audioStream);
		}
	}
	
	public void executa(CentralAudio.ID id){
		_dicAudio[id].Play();
	}
	
	
	//Erro de falta de nó
	private void _ErroFaltaNo(String nomeNo){
		GD.Print("Falta o ", nomeNo, this);
		GetTree().Quit();
	}
	
	//Retorna o No e verifica se ele existe
	private T _GetNode<T>(string nome)  where T : class {
		T t = GetNode<T>(nome);
		if(t == null){
			_ErroFaltaNo(nome);
		}
		return t;
	}
}
