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
		dashTimer.Timeout +=()=> DashOver();
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
		character.applyGravity();
		character.MoveAndSlide();
		
    }


    protected override void Enter()
    {
        base.Enter();
		character.animPlayerNode.Play(GameConstants.ANIM_DASH);
		dashTimer.Start();
		character.moveSpeed = _dashSpeed;
		character.setVelocity();
	}

    private void DashOver()
	{
		if ( character.inputDirection == Vector2.Zero ) character.stateMachine.SwitchState<PlayerIdleState>();
		if ( character.inputDirection != Vector2.Zero ) character.stateMachine.SwitchState<PlayerMoveState>();
	}

}
