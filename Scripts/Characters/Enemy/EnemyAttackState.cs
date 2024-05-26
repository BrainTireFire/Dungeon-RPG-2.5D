using Godot;
using System;
using System.Linq;
using DungeonRPG2.D.Scripts.General;

public partial class EnemyAttackState : EnemyState
{
    private Vector3 _targetPosition;
    
    protected override void EnterState()
    {
        characterNode.AnimationPlayerNode.Play(GameConstants.ANIM_ATTACK);
        
        Node3D target = characterNode.AttackAreaNode.GetOverlappingBodies().First();
        
        _targetPosition = target.GlobalPosition;
        
        characterNode.AnimationPlayerNode.AnimationFinished += HandleAnimationFinished;
    }
    
    protected override void ExitState()
    {
        characterNode.AnimationPlayerNode.AnimationFinished -= HandleAnimationFinished;
    }

    private void HandleAnimationFinished(StringName animname)
    {
        characterNode.ToggleHitbox(true);
        
        Node3D target = characterNode.AttackAreaNode.GetOverlappingBodies().FirstOrDefault();

        if (target == null)
        {
            Node3D chaseTarget = characterNode.ChaseAreaNode.GetOverlappingBodies().FirstOrDefault();

            if (chaseTarget == null)
            {
                characterNode.StateMachineNode.SwitchState<EnemyReturnState>();
                return;
            }
            
            characterNode.StateMachineNode.SwitchState<EnemyChaseState>();
            return;
        }

        characterNode.AnimationPlayerNode.Play(GameConstants.ANIM_ATTACK);
        _targetPosition = target.GlobalPosition;
        
        Vector3 direction = characterNode.GlobalPosition.DirectionTo(_targetPosition);
        characterNode.SpriteNode.FlipH = direction.X < 0; // if negative character is facing left
    }

    private void PerformHit()
    {
        characterNode.ToggleHitbox(false);
        characterNode.HitboxxNode.GlobalPosition = _targetPosition;
    }
}
