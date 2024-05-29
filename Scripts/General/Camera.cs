using Godot;
using System;
using DungeonRPG2.D.Scripts.General;

public partial class Camera : Camera3D
{
    [Export] private Node _target;
    [Export] private Vector3 _positionFromTarget;
    public override void _Ready()
    {
        GameEvents.OnStartGame += HandleStartGame;
        GameEvents.OnEndGame += HandleEndGame;
    }
    
    private void HandleStartGame()
    {
        Reparent(_target);

        Position = _positionFromTarget;
    }
    
    private void HandleEndGame()
    {
        Reparent(GetTree().CurrentScene);
    }
}
