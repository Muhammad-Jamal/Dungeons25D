using Godot;
using System;

public partial class PlayerIdleState : Node
{

	Player player;
	

	public override void _Ready()
	{
		player = GetOwner<Player>();
	}




	public override void _Process(double delta)
	{
		if(player.inputDirection != Vector2.Zero) player.stateMachine.SwitchState<PlayerMoveState>();

	}




    public override void _Notification(int what)
    {



        base._Notification(what);

		if(what == 5001)
		{
			player.animPlayerNode.Play(GameConstants.ANIM_IDLE);
			SetProcess(true);
		}
		if(what == 5002)
		{
			SetProcess(false);
		}



    }
}
