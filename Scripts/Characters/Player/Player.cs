using Godot;
using System;
using DungeonRPG2.D.Scripts.Characters;
using DungeonRPG2.D.Scripts.General;

public partial class Player : Character
{
    public override void _Input(InputEvent @event)
    {
        direction = Input.GetVector(
            GameConstants.INPUT_MOVE_LEFT, 
            GameConstants.INPUT_MOVE_RIGHT, 
            GameConstants.INPUT_MOVE_FORWARD, 
            GameConstants.INPUT_MOVE_BACKWARD
        );
    }
}
