using Godot;
using System;

public class BlocoGerador : BlocoInterativo
{
	[Export]
	protected string _caminhoCena = "";
	[Export]
	protected int _tempo = 0;
	
	protected PackedScene _cena;
	protected Node _gerados;
	protected bool _destroir = false;

	//Temporizador
	protected Timer _temporizador;
	private bool _temporizadorConfig = false;

	protected bool _proxEstado = false;

	protected override void _Referencia(){
		base._Referencia();
		_cena = (PackedScene) ResourceLoader.Load(_caminhoCena);
		Godot.Collections.Array array = GetTree().GetNodesInGroup("Gerados");
		if(array == null){
			GD.Print("Não encontrado o Node 'Gerados'");
			GetTree().Finish();
		}
		_gerados = (Node) array[0];
		_temporizador = _GetNode<Timer>("Timer");

	}
	
	protected virtual void _Gera(){
		if(_cena != null){
			Node2D node = (Node2D) _cena.Instance();
			node.GlobalPosition = _CalculaPosInicial();
			_gerados.AddChild(node);
			if(_tempo > 0){
				_ConfigTemporizado();
			}
			else{
				_proxEstado = true;
			}
		}
		else{
			_proxEstado = true;
		}
		
	}


	private Vector2 _CalculaPosInicial(){
		return new Vector2(GlobalPosition.x, GlobalPosition.y - 40);
	}

	private  void _ConfigTemporizado(){
		if(_temporizadorConfig == false){
			_temporizador.WaitTime = _tempo;
			_temporizador.Start();
			_temporizador.Connect("timeout", this, nameof(ForcaProxEstado));
			_temporizadorConfig = true;
		}
	}


	private void ForcaProxEstado(){
		_proxEstado = true;
	}


	protected override void _Acao(){
		_Gera();
		if(_proxEstado){
			ProxEstado();
			_proxEstado = false;
		}
	}


}
