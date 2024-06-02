using Godot;
using System;

public partial class PlayerMoveState : PlayerState
{

	[Export] protected float _moveSpeed = 5.0f;

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(character.inputDirection == Vector2.Zero)
		{ 
			character.stateMachine.SwitchState<PlayerIdleState>();
		}
		else if (Input.IsActionJustPressed(GameConstants.INPUT_DASH)) 
		{ 
			character.stateMachine.SwitchState<PlayerDashState>();
		}
	}

    public override void _PhysicsProcess(double delta)
    { 
		character.setVelocity();
		character.applyGravity();
		character.MoveAndSlide();
    }


	public override void Enter()
	{
		character.animPlayerNode.Play(GameConstants.ANIM_WALK);
		character.moveSpeed = _moveSpeed;
	}
}

