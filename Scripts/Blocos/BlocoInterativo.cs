using Godot;
using System;

public class BlocoInterativo : Bloco
{
	public enum Dir{
		BAIXO,
		ESQ,
		DIR,
	}


	public void Executa(Dir dir = Dir.BAIXO){
		if(dir == Dir.BAIXO){
			_ExecutaAnim(ANIM_PARA_CIMA);
		}
		_Acao();
	}


	protected virtual void _Acao(){
		return;
	}

	//Usado para mudar o estado do bloco;
	public virtual void ProxEstado(){
		return;
	}
}
