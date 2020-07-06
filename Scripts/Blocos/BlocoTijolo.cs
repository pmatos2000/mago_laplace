using Godot;
using System;

public class BlocoTijolo : BlocoGerador{

	public override void ProxEstado(){
		_Destroi();
	}
	
}

