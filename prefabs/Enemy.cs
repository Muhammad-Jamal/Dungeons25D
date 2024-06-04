using Godot;
using System;

public partial class Enemy : Character
{
    public Player player;
    [Export] public Area3D detectionArea;
    public override void _Ready()
    {
        base._Ready();
        path = GetParent<Path3D>();
        GD.Print(path);
    }

    public void attack(){
        GD.Print("Attack");
    }
}
