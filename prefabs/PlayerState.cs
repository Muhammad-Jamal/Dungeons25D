using Godot;
using System;

public abstract partial class PlayerState : Node
{

	protected Player player;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		base._Ready();
		SetPhysicsProcess(false);
		SetProcess(false);
		SetProcessInput(false);
		player = GetOwner<Player>();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
		//player.applyGravity();
    }
	public override void _Notification(int what)
    {
        base._Notification(what);

		if(what == GameConstants.NOTIFIACTION_ENTER_STATE)
		{
			
			SetPhysicsProcess(true);
			SetProcess(true);
			SetProcessInput(true);
			Enter();
		}
		if(what == GameConstants.NOTIFIACTION_EXIT_STATE)
		{
			SetPhysicsProcess(false);
			SetProcess(false);
			SetProcessInput(false);
		}
    }

	protected virtual void Enter()
	{

	}
}
