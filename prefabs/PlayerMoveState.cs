using Godot;
using System;

public partial class PlayerMoveState : Node
{
	// Called when the node enters the scene tree for the first time.
	Player player;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		player = GetOwner<Player>();
		SetProcess(false);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(player.inputDirection == Vector2.Zero) player.stateMachine.SwitchState<PlayerIdleState>();
		
	}

	 public override void _Notification(int what)
    {
        base._Notification(what);

		if(what == 5001)
		{
			player.animPlayerNode.Play(GameConstants.ANIM_WALK);
			SetProcess(true);
		}
		if(what == 5002)
		{
			SetProcess(false);
		}
    }
}

