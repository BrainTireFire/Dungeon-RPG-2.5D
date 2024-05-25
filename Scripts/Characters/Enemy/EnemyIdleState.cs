using Godot;
using System;
using DungeonRPG2.D.Scripts.General;

public partial class EnemyIdleState : EnemyState
{
    protected override void EnterState()
    {
        base.EnterState();
     
        characterNode.AnimationPlayerNode.Play(GameConstants.ANIM_IDLE);
        
        characterNode.ChaseAreaNode.BodyEntered += HandleChaseAreaBodyEntered;
    }
    
    protected override void ExitState()
    {
        characterNode.ChaseAreaNode.BodyEntered -= HandleChaseAreaBodyEntered;
    }

    public override void _PhysicsProcess(double delta)
    {
        characterNode.StateMachineNode.SwitchState<EnemyReturnState>();
    }
}
