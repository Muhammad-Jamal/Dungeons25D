using Godot;
using System;

public partial class CameraControls : Camera3D
{
	[Export] protected Vector3 _offset;
	[Export] protected Player _player;
	[Export] protected float _speed = 2.0f;
    public override void _Ready()
    {
        base._Ready();
	//	_player = GetParent<Player>();
	//	_offset = new Vector3(0, 4, 7);
    }

    public override void _Process(double delta)
	{
		Position = Position.Lerp(_player.Position, ((float)delta)  * _speed);
		Position += _offset;
	}
}
