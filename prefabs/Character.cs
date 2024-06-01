using Godot;
using System;

public abstract partial class Character : CharacterBody3D
{
	[Export] public Sprite3D playerSprite;
	[Export] public AnimationPlayer animPlayerNode;
	[Export] public StateMachine stateMachine;
	public float moveSpeed = 5.0f;
	public Vector2 inputDirection;



	public virtual void applyGravity(){
		//if (Velocity.Y < -0.5f) return;
		if (IsOnFloor()) return;
		Velocity = new (Velocity.X, Velocity.Y - 9.8f * (float) GetPhysicsProcessDeltaTime(), Velocity.Z);
		GD.Print(Velocity.Y, GetPhysicsProcessDeltaTime());
	}

	public virtual void flip(){
		if( Velocity.X != 0.0f ){
			if (Velocity.X < 0.0f) playerSprite.FlipH = true;
			else playerSprite.FlipH = false;
		}
	}
	public void setVelocity()
	{

		Velocity = new (inputDirection.X * moveSpeed, Velocity.Y, inputDirection.Y * moveSpeed);
		flip();
	}

}
