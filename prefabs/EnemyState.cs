using Godot;
using System;

public partial class EnemyState : CharacterState
{
	protected Vector3 destination;
	// Called when the node enters the scene tree for the first time.
	protected Enemy enemyCharacter;
	public override void _Ready()
	{
		base._Ready();
		if (character is Enemy) enemyCharacter = (Enemy)character; 
		enemyCharacter.detectionArea.BodyEntered += handleEnteredBody;
		enemyCharacter.detectionArea.BodyExited += handleBodyExited;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		base._Process(delta);

	}
    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
    }

    public override void Enter()
    {
        base.Enter();
		
    }

    private void handleBodyExited(Node3D body)
    {
        GD.Print(body);
		if(body is Player)
        {
			enemyCharacter.player = null;
			enemyCharacter.stateMachine.SwitchState<EnemyReturnState>();
		}
    }


    private void handleEnteredBody(Node3D body)
    {
		GD.Print(body);
		if(body is Player)
        {
			enemyCharacter.player = (Player)body;
			enemyCharacter.navigationAgent3D.TargetPosition = enemyCharacter.player.GlobalPosition;
			enemyCharacter.stateMachine.SwitchState<EnemyChaseState>();
		}
    }

    public Vector3 GetPathGlobalCords(int index){
	//	GD.Print(character.path);
        return character.path.GlobalPosition + character.path.Curve.GetPointPosition(index);
    }
    public override void Exit()
    {
        base.Exit();
    }

}
