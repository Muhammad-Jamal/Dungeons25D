using Godot;
using System;

public abstract partial class PlayerState : CharacterState
{



	public override void _Process(double delta)
	{
	}

	public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
    }
}
