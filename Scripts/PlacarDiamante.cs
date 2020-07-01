using Godot;
using System;

public class PlacarDiamante : Node2D
{
	//Frames
	private const int _FRAME_DIAMANTE_ARCOIRIS = 0;
	private const int _FRAME_DIAMANTE_CINZA = 1;
	private Memoria memLocal;
	
	//Nomes para buscar na memoria local
	private static String [] _NOMES = new String[]{ "Diamante_0",
													"Diamante_1",
													"Diamante_2"};
	
	private Sprite[] _diamante = new Sprite[3];
	
	public override void _Ready(){
		memLocal = GetNode<Memoria>("/root/MemLocal");
		Godot.Collections.Array filhos =  GetChildren();
			for(int i = 0; i < 3; i++){
				_diamante[i] = (Sprite) filhos[i];
				_diamante[i].Frame = _FRAME_DIAMANTE_CINZA;
			}
			Atualiza();
	}
	
	public void Atualiza(){
		bool pego;
		for(int i = 0; i < 3; i++){
			pego = memLocal.GetBool(_NOMES[i]);
			if(pego){
				_diamante[i].Frame = _FRAME_DIAMANTE_ARCOIRIS;
			}
			else{
				_diamante[i].Frame = _FRAME_DIAMANTE_CINZA;
			}
		}
	}

}
