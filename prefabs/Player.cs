using Godot;
using System;
using System.Security.Cryptography.X509Certificates;

public partial class Player : CharacterBody3D
{
	[Export] Sprite3D playerSprite;
	[Export] public AnimationPlayer animPlayerNode;
	[Export] public StateMachine stateMachine;
	public Vector2 inputDirection;
	public float moveSpeed = 5.0f;


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

    public void setVelocity(){
		Velocity = new (inputDirection.X, Velocity.Y, inputDirection.Y);
		Velocity *= moveSpeed; 
		flip();
	}
	public void applyGravity(){
		Velocity = new (Velocity.X, Velocity.Y - 9.8f * (float)GetPhysicsProcessDeltaTime(), Velocity.Z);
	}

	public void flip(){
		if( Velocity.X != 0.0f ){
			if (Velocity.X < 0.0f) playerSprite.FlipH = true;
			else playerSprite.FlipH = false;
		}
		
	}

}
