using Godot;
using System;

public partial class EnemyIdleState : EnemyState
{
	// Called when the node enters the scene tree for the first time.
public override void _Process(double delta)
	{
		//if(character.inputDirection != Vector2.Zero) character.stateMachine.SwitchState<PlayerMoveState>();

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
		character.animPlayerNode.Play(GameConstants.ANIM_IDLE);
    }
}
