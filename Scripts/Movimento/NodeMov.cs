using Godot;
using System;

public class NodeMov : Node2D
{

    protected static Vector2 _dirParaCima = new Vector2(0,-1);

    protected Vector2 _mov;

    public Vector2 Mov{
        set => _mov = value;
    }

    public override void _PhysicsProcess(float delta){
        _Pos(delta);
        _Ang(delta);
    }

    //Atualiza a posição
    protected virtual void _Pos(float delta){
        return;
    }

    //Atualiza o angulo
    protected virtual void _Ang(float delta){
        return;
    }
}
