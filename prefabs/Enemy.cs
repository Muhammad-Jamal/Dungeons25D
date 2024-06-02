using Godot;
using System;

public partial class Enemy : Character
{
    public override void _Ready()
    {
        base._Ready();
        path = GetParent<Path3D>();
        GD.Print(path);
    }

}
