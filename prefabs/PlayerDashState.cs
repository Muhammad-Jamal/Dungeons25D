using Godot;
using System;
using System.Diagnostics.Contracts;

public partial class PlayerDashState : Node
{
	Player player;

    public override void _Ready()
    {
		SetProcess(false);
        base._Ready();
		player = GetOwner<Player>();
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
		
    }

    public override void _Notification(int what)
    {

        base._Notification(what);

		if(what == 5001)
		{
			player.animPlayerNode.Play(GameConstants.ANIM_DASH);
			player.moveSpeed = 20.0f;
			SetProcess(true);
			GD.Print("Dash");
		}
		if(what == 5002)
		{
			SetProcess(false);
		}

    }

}
