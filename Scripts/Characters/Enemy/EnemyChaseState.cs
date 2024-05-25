using Godot;
using System;
using System.Linq;
using DungeonRPG2.D.Scripts.General;

public partial class EnemyChaseState : EnemyState
{
    [Export] private Timer _timerNode;
    
    private CharacterBody3D _target;
    
    protected override void EnterState()
    {
        characterNode.AnimationPlayerNode.Play(GameConstants.ANIM_MOVE);
        
        _target = characterNode.ChaseAreaNode.GetOverlappingBodies().First() as CharacterBody3D;
        
        _timerNode.Timeout += HandleTimeout;
        characterNode.AttackAreaNode.BodyEntered += HandleAttackAreaBodyEntered;
        characterNode.ChaseAreaNode.BodyExited += HandleChaseAreaBodyExited;
    }
    
    protected override void ExitState()
    {
        _timerNode.Timeout -= HandleTimeout;
        characterNode.AttackAreaNode.BodyEntered -= HandleAttackAreaBodyEntered;
        characterNode.ChaseAreaNode.BodyExited -= HandleChaseAreaBodyExited;
    }

    public override void _PhysicsProcess(double delta)
    {
        Move();
    }
    
    private void HandleTimeout()
    {
        _destination = _target.GlobalPosition;
        characterNode.AgentNode.TargetPosition = _destination;
    }
    
    private void HandleAttackAreaBodyEntered(Node3D body)
    {
        characterNode.StateMachineNode.SwitchState<EnemyAttackState>();
    }
    
    private void HandleChaseAreaBodyExited(Node3D body)
    {
        characterNode.StateMachineNode.SwitchState<EnemyReturnState>();
    }
}
