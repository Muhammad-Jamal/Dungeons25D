using Godot;
using System;

public partial class PlayerIdleState : PlayerState
{
	

	public override void _Ready()
	{
		player = GetOwner<Player>();
	}




	public override void _Process(double delta)
	{
		if(player.inputDirection != Vector2.Zero) player.stateMachine.SwitchState<PlayerMoveState>();

	}

    protected override void Enter()
    {
        base.Enter();
		player.animPlayerNode.Play(GameConstants.ANIM_IDLE);
    }

}
