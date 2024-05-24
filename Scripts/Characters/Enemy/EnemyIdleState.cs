using Godot;
using System;
using DungeonRPG2.D.Scripts.General;

public partial class EnemyIdleState : EnemyState
{
    protected override void EnterState()
    {
        base.EnterState();
     
        characterNode.AnimationPlayerNode.Play(GameConstants.ANIM_IDLE);
    }
}
