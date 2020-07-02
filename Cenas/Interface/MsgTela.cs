using Godot;
using System;

public class MsgTela : ColorRect
{
	private Label _label;
	private AnimationPlayer _anim;
	private bool _ativo = false;
	private bool _travaAnim = false;
	
	public override void _Ready(){
		_label = GetNode<Label>("Label");
		_anim = GetNode<AnimationPlayer>("AnimationPlayer");
	}
	
	public void AtivaQuadro(string texto = ""){
		_label.Text = texto;
		_anim.Play("Aparecer");
		//Pausa os outros eventos
		GetTree().Paused = true;
		
	}
	
	public void DesativaQuadro(){
		_anim.Play("Desaparecer");
	}
	
	public override void _Process(float delta){
		if(_ativo && !_travaAnim){
			//Qualquer tecla serve para desativar
			if( Input.IsActionPressed("ui_left") ||
				Input.IsActionPressed("ui_right") ||
				Input.IsActionPressed("ui_a") ){
					_travaAnim = true;
					DesativaQuadro();
					GetTree().Paused = false;
				}
		}
	}
	
	private void _FimAnimacao(bool ativo){
		_travaAnim = false;
		_ativo = ativo;
	}

}
