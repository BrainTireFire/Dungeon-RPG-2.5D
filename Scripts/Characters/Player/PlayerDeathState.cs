using Godot;
using System;
using DungeonRPG2.D.Scripts.General;

public partial class PlayerDeathState : PlayerState
{
    protected override void EnterState()
    {
        characterNode.AnimationPlayerNode.Play(GameConstants.ANIM_DEATH);
        
        characterNode.AnimationPlayerNode.AnimationFinished += HandleAnimationFinished;
    }
    
    private void HandleAnimationFinished(StringName animname)
    {
        GameEvents.RaiseEndGame();
        
        characterNode.QueueFree();
    }
}
