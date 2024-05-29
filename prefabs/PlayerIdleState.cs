using Godot;
using System;

public partial class PlayerIdleState : Node
{

	Player player;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		player = GetOwner<Player>();
		player.animPlayerNode.Play(GameConstants.ANIM_IDLE);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
