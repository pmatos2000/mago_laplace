using Godot;
using System;

public class Tela : Node
{
	
	private Viewport viewport;
	
	public override void _Ready(){
		viewport = GetViewport();
		GetTree().Connect("screen_resized", this, nameof(_ScreenResized));
	}
	
	//Pixel perfeito
	private void _ScreenResized(){
		
		//Dimensão da tela
		Vector2 telaDim = OS.WindowSize;
		
		//Calcula o valor maximo que pode escalonar
		int escalaX = (int) Math.Floor(telaDim.x / viewport.Size.x);
		int escalaY = (int) Math.Floor(telaDim.y / viewport.Size.y);
		int escala = Math.Max(1, Math.Min(escalaX, escalaY)); //O minimo é 1
		
		//Centraliza a janela
		Vector2 dif = (telaDim - (viewport.Size * escala));
		Vector2 centro = (dif * 0.5f).Floor();
		
		//Configura a exibição
		Rect2 rect2 = new Rect2(centro, viewport.Size * escala);
		viewport.SetAttachToScreenRect(rect2);
	}

	//Muda para full screen
	public override void _UnhandledInput(InputEvent evento){
		if(evento.IsActionPressed("full_screen")){
			OS.WindowFullscreen = !OS.WindowFullscreen;
		}
	}
	

}
