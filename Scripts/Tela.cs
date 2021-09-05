using Godot;
using System;

public class Tela : Node
{
	
	private Viewport viewport;
	
	public override void _Ready(){
		viewport = GetViewport();
		viewport.RenderTargetClearMode = 2;
		GetTree().Connect("screen_resized", this, nameof(_ScreenResized));
	}
	
	//Pixel perfeito
	private void _ScreenResized(){
		

		
		
		//Dimensão da tela
		Vector2 telaDim = OS.WindowSize;
		
		//Calcula o valor maximo que pode escalonar
		//int escalaX = (int) Math.Floor(telaDim.x / viewport.Size.x);
		var escalaY =  (float) Math.Floor(telaDim.y / viewport.Size.y);
		//int escala = Math.Max(1, escalaY); //O minimo é 1
		
		//Centraliza a janela
		Vector2 dif = (telaDim - (viewport.Size * escalaY));
		Vector2 centro = (dif * 0.5f).Floor();
		
		//Configura a exibição
		Rect2 rect2 = new Rect2(centro, viewport.Size * escalaY);
		viewport.SetAttachToScreenRect(rect2);
		
		sceneTree.RemoveChild(backgroundOverlay);
		backgroundOverlay.QueueFree();
	}

	//Muda para full screen
	public override void _UnhandledInput(InputEvent evento){
		if(evento.IsActionPressed("full_screen")){
			OS.WindowFullscreen = !OS.WindowFullscreen;
		}
	}	
	
}
