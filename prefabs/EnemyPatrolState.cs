using Godot;
using System;

public partial class EnemyPatrolState : EnemyState
{

	private int path3dIndex = 0;
	public override void _Ready()
	{
		base._Ready();
	}
    public override void Enter()
    {
        base.Enter();
        character.animPlayerNode.Play(GameConstants.ANIM_WALK);
        setDestination(0);
    }

    private void setDestination(int index)
    {
        destination = GetPathGlobalCords(index) - character.GlobalPosition;
        character.navigationAgent3D.TargetPosition = destination;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.

    public override void _Process(double delta)
	{
        base._Process(delta);
	}
    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
        //GD.Print(character);

		if (character.navigationAgent3D.IsNavigationFinished()) {
			path3dIndex++;
			setDestination(path3dIndex);
			if (path3dIndex == character.path.Curve.PointCount - 1) path3dIndex = 0;
		}
        Move();
    }

    private void Move()
    {
        character.setVelocityInDir(character.GlobalPosition.DirectionTo(character.navigationAgent3D.GetNextPathPosition()));
        character.flip();
        character.MoveAndSlide();
    }

}
