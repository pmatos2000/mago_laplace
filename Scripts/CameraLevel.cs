using Godot;
using mago_laplace.Scripts.Constantes;
using System;

public class CameraLevel : Camera2D
{
	[Export]
	private readonly NodePath caminhoRef = null;
	[Export]
	private readonly MovimentoCamera movimentoCamera = MovimentoCamera.HORIZONTAL;

	private Node2D noRef;
	
	public override void _Ready(){
		ObterReferencias();
		AtualizarLimites();
	}

	public void AtualizarLimites()
    {
		LimitBottom = Constantes.Sistema.ALTURA_TELA;
		LimitLeft = 0;
		switch (movimentoCamera)
        {
            case MovimentoCamera.HORIZONTAL:
				LimitTop = 0;
				LimitRight = int.MaxValue;
				break;
			case MovimentoCamera.VERTICAL:
				LimitTop = int.MinValue;
				LimitRight = Constantes.Sistema.LARGURA_TELA;
				break;
			case MovimentoCamera.LIVRE:
				LimitTop = int.MinValue;
				LimitRight = int.MaxValue;
				break;
		}
    }
	
	private void ObterReferencias(){
		noRef = MetodosUteis.ObterNo<Node2D>(this, caminhoRef);
	}
	

	public override void _Process(float delta){
		Position = noRef.GlobalPosition;
	}

}
