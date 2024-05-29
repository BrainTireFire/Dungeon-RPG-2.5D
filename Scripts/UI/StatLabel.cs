using Godot;
using System;
using DungeonRPG2.D.Scripts.Resources;

public partial class StatLabel : Label
{
    [Export] private StatResource _statResource;

    public override void _Ready()
    {
        _statResource.OnUpdate += HandleStatUpdate;
        
        Text = _statResource.StatValue.ToString();
    }

    private void HandleStatUpdate()
    {
        Text = _statResource.StatValue.ToString();
    }
}
