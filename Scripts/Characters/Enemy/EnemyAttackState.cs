using Godot;
using System;
using DungeonRPG2.D.Scripts.General;

public partial class EnemyAttackState : EnemyState
{
    
    protected override void EnterState()
    {
        characterNode.AnimationPlayerNode.Play(GameConstants.ANIM_ATTACK);
    }
}
