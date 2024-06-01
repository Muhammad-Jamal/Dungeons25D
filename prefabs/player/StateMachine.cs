using Godot;
using System;

public partial class StateMachine : Node
{

	[Export] private Node currentState;
	[Export] private Node[] states;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		currentState._Notification(GameConstants.NOTIFIACTION_ENTER_STATE);
	}
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}
	public override void _PhysicsProcess(double delta)
	{
		
	}

	public void SwitchState<T>()
	{
		Node newState = null;
		foreach(Node state in states)
		{
			if (state is T) 
			{
				newState = state;
			}
		}

		if (newState == null)
		{
			return;
		}
		currentState.Notification(GameConstants.NOTIFIACTION_EXIT_STATE);
		currentState = newState;
		currentState.Notification(GameConstants.NOTIFIACTION_ENTER_STATE);
	}

}
