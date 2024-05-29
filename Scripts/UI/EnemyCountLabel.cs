using Godot;
using System;
using DungeonRPG2.D.Scripts.General;

public partial class EnemyCountLabel : Label
{
    public override void _Ready()
    {
        GameEvents.OnNewEnemyCount += HandleNewEnemyCount;
    }

    private void HandleNewEnemyCount(int count)
    {
        Text = count.ToString();
    }
}
