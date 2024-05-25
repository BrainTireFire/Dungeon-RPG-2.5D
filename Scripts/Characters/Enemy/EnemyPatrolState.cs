using Godot;
using System;
using DungeonRPG2.D.Scripts.General;

public partial class EnemyPatrolState : EnemyState
{
    [Export] private Timer _idleTimerNode;
    [Export(PropertyHint.Range, "0,20,0.1")] private float _maxIdleTime = 4;
    
    private int _pointIndex = 0;

    
    protected override void EnterState()
    {
        characterNode.AnimationPlayerNode.Play(GameConstants.ANIM_MOVE);

        _pointIndex = 1;
        
        _destination = GetPointGlobalPosition(_pointIndex);
        characterNode.AgentNode.TargetPosition = _destination;
        
        characterNode.AgentNode.NavigationFinished += HandleNavigationFinished;
        _idleTimerNode.Timeout += HandleTimeout;

        characterNode.ChaseAreaNode.BodyEntered += HandleChaseAreaBodyEntered;
    }

    protected override void ExitState()
    {
        characterNode.AgentNode.NavigationFinished -= HandleNavigationFinished;
        _idleTimerNode.Timeout -= HandleTimeout;
        characterNode.ChaseAreaNode.BodyEntered -= HandleChaseAreaBodyEntered;
    }

    public override void _PhysicsProcess(double delta)
    {
        if (!_idleTimerNode.IsStopped())
        {
            return;
        }
        
        Move();
    }
    
    private void HandleNavigationFinished()
    {
        characterNode.AnimationPlayerNode.Play(GameConstants.ANIM_IDLE);

        RandomNumberGenerator rng = new();
        _idleTimerNode.WaitTime = rng.RandfRange(0, _maxIdleTime);
        _idleTimerNode.Start();
    }
    
    private void HandleTimeout()
    {
        characterNode.AnimationPlayerNode.Play(GameConstants.ANIM_MOVE);
        
        _pointIndex = Mathf.Wrap(_pointIndex + 1, 0, characterNode.PathNode.Curve.PointCount);
        
        _destination = GetPointGlobalPosition(_pointIndex);
        characterNode.AgentNode.TargetPosition = _destination;
    }
}
