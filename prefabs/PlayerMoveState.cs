using Godot;
using System;

public partial class PlayerMoveState : PlayerState
{

	[Export] protected float _moveSpeed = 5.0f;
	public override void _Ready()
	{
		player = GetOwner<Player>();
		SetProcess(false);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(player.inputDirection == Vector2.Zero)
		{ 
			player.stateMachine.SwitchState<PlayerIdleState>();
		}
		else if (Input.IsActionJustPressed(GameConstants.INPUT_DASH)) 
		{ 
			player.stateMachine.SwitchState<PlayerDashState>();
		}
	}

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);

		player.setVelocity();
		player.MoveAndSlide();
    }


	protected override void Enter()
	{
		player.animPlayerNode.Play(GameConstants.ANIM_WALK);
		player.moveSpeed = _moveSpeed;
	}
}

