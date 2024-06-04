using Godot;
using System;

public partial class EnemyChaseState : EnemyState
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		base._Ready();
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		base._Process(delta);
	}
	public override void Enter(){
		base.Enter();
	}

	public override void Exit(){
		base.Exit();
	}

	 public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
		if(enemyCharacter.navigationAgent3D.IsNavigationFinished()){ enemyCharacter.attack();}

		destination = enemyCharacter.player.GlobalPosition;
		enemyCharacter.navigationAgent3D.TargetPosition = destination;
		var nextPoint = enemyCharacter.navigationAgent3D.GetNextPathPosition();
		enemyCharacter.setVelocityInDir(enemyCharacter.GlobalPosition.DirectionTo(nextPoint));
		enemyCharacter.MoveAndSlide();
    }


}
