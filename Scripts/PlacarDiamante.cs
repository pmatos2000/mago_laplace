using Godot;
using System;

public class PlacarDiamante : Node2D
{
	private static readonly int FRAME_DIAMANTE_ARCOIRIS = 0;
	private static readonly int FRAME_DIAMANTE_CINZA = 1;
	
	private readonly Sprite[] vetorSprinteDiamante = new Sprite[3];
	
	public void ModificarStatusDiamantes(Diamante.Id idDiamante)
    {
		var id = (uint) idDiamante;
		vetorSprinteDiamante[id].Frame = FRAME_DIAMANTE_ARCOIRIS;
	}

	public override void _Ready(){
		var filhos =  GetChildren();
		for(int i = 0; i < 3; i++){
			if(filhos[i] is Sprite sprite)
            {
				vetorSprinteDiamante[i] = sprite;
				vetorSprinteDiamante[i].Frame = FRAME_DIAMANTE_CINZA;
			}
		}
	}
	

}
