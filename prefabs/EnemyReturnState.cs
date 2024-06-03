using Godot;
using System;
using System.IO;

public partial class EnemyReturnState : EnemyState
{
	Vector3 directionToDestination;
    public override async void _Ready()
    {
        base._Ready();
        
         
    }

    public override void Enter()
    {
        base.Enter();
        directionToDestination = character.path.Curve.GetPointPosition(0);
		character.animPlayerNode.Play(GameConstants.ANIM_WALK);
    }
    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
        Vector3 destinationDir = character.GlobalPosition - (character.path.GlobalPosition + character.path.Curve.GetPointPosition(0));
        character.setVelocityInDir(destinationDir.Normalized());
        character.MoveAndSlide();
    }
}
