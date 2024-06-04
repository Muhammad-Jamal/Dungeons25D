using Godot;
using System;
using System.IO;

public partial class EnemyReturnState : EnemyState
{
    public override void _Ready()
    {
        base._Ready();
    }
    public override void Enter()
    {
        base.Enter();
		character.animPlayerNode.Play(GameConstants.ANIM_WALK);
        destination = GetPathGlobalCords(0) - character.GlobalPosition ;
		character.navigationAgent3D.TargetPosition = destination;

    }
    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
        character.stateMachine.SwitchState<EnemyPatrolState>();
    }

}
