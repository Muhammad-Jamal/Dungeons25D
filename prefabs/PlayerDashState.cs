using Godot;
using System;
using System.Diagnostics.Contracts;

public partial class PlayerDashState : PlayerState
{

	[Export] private Timer dashTimer;
	[Export] protected float _dashSpeed = 20.0f;
    public override void _Ready()
    {
		SetPhysicsProcess(false);
		SetProcess(false);
        base._Ready();
		player = GetOwner<Player>();
		dashTimer.Timeout +=()=> DashOver();
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
		player.MoveAndSlide();
		
    }


    protected override void Enter()
    {
        base.Enter();
		player.animPlayerNode.Play(GameConstants.ANIM_DASH);
		dashTimer.Start();
		player.moveSpeed = _dashSpeed;
		player.setVelocity();
	}

    private void DashOver()
	{
		if ( player.inputDirection == Vector2.Zero ) player.stateMachine.SwitchState<PlayerIdleState>();
		if ( player.inputDirection != Vector2.Zero ) player.stateMachine.SwitchState<PlayerMoveState>();
	}

}
