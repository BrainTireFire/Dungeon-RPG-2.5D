using Godot;
using System;
using DungeonRPG2.D.Scripts.General;

public partial class EnemyReturnState : EnemyState
{
    public override void _Ready()
    {
        base._Ready();
        
        _destination = GetPointGlobalPosition(0);
    }

    protected override void EnterState()
    {
        characterNode.AnimationPlayerNode.Play(GameConstants.ANIM_MOVE);
        
        characterNode.AgentNode.TargetPosition = _destination;
        
        characterNode.ChaseAreaNode.BodyEntered += HandleChaseAreaBodyEntered;
    }
    
    protected override void ExitState()
    {
        characterNode.ChaseAreaNode.BodyEntered -= HandleChaseAreaBodyEntered;
    }
    
    public override void _PhysicsProcess(double delta)
    {
        if (characterNode.AgentNode.IsNavigationFinished())
        {
            characterNode.StateMachineNode.SwitchState<EnemyPatrolState>();
            return;
        }

        Move();
    }
}
