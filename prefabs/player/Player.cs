using Godot;
using System;
using System.Security.Cryptography.X509Certificates;

public partial class Player : Character
{
	
	public override void _Input(InputEvent @event)
	{
		inputDirection = Input.GetVector(GameConstants.INPUT_LEFT, GameConstants.INPUT_RIGHT,GameConstants.INPUT_UP , GameConstants.INPUT_DOWN );
		
	}

	public override void _Ready()
	{
		base._Ready();
	}

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
    }



}
