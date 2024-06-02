using Godot;
using System;

public partial class PlayerIdleState : PlayerState
{
	
	public override void _Process(double delta)
	{
		if(character.inputDirection != Vector2.Zero) character.stateMachine.SwitchState<PlayerMoveState>();

	}

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
		character.applyGravity();
		character.MoveAndSlide();
    }

    public override void Enter()
    {
        base.Enter();
		character.animPlayerNode.Play(GameConstants.ANIM_IDLE);
    }

}
