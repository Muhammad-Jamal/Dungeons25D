using Godot;
using System;

public abstract partial class CharacterState : Node
{

	protected Character character;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		base._Ready();
		character = GetOwner<Character>();
		SetPhysicsProcess(false);
		SetProcess(false);
		SetProcessInput(false);
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
