using Godot;
using System;

public class CaranguejoLaranja : Inimigo
{
	public override void _Ready(){
		base._Ready();
		_DirInicial();
	}
	
	private void _DirInicial(){
		if(_jogador != null){
			if(GlobalPosition.x > _jogador.GlobalPosition.x){
				controle.esq = true;
			}
			else{
				controle.dir = true;
			}
		}
		else{
			Random randNum = new Random();
			if(randNum.Next() % 2 == 0){
				controle.esq = true;
			}
			else{
				controle.dir = true;
			}
		}
	}
	
	public override void SetValorPadrao(){
		AceDesl = 15;
		MovMax = new Vector2(100,500);
		VidaMax = 1;
		ManaMax = 0;
	}
	
	protected override void _AtualizaControle(){
		controle.naParede = IsOnWall();
		if(controle.naParede){
			controle.esq = !controle.esq;
			controle.dir = !controle.dir;
		}
	}
	
	protected override void _Movimento(){
		Vector2 mov = Mov;
		
		//Gravidade
		mov.y += Gravidade;
		
		//Controle
		if(controle.dir){
			mov.x += (AceDesl - Atrito);
		}
		else if(controle.esq){
			mov.x -= (AceDesl - Atrito);
		}
		
		//Atualiza o mov
		Mov = mov;
	}
}
