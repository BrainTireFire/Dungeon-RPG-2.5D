﻿using DungeonRPG2.D.Scripts.Characters;
using DungeonRPG2.D.Scripts.General;
using DungeonRPG2.D.Scripts.Resources;
using Godot;

public abstract partial class PlayerState : CharacterState
{
    public override void _Ready()
    {
        base._Ready();
        
        characterNode.GetStatResource(Stat.Health).OnZero += HandleZeroHealth;
    }
    
    protected void CheckForAttackInput()
    {
        if (Input.IsActionJustPressed(GameConstants.INPUT_ATTACK))
        {
           characterNode.StateMachineNode.SwitchState<PlayerAttackState>();
        }
    }
    
    private void HandleZeroHealth()
    {
        characterNode.StateMachineNode.SwitchState<PlayerDeathState>();
    }
}