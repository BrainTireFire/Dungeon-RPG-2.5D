using Godot;
using System;
using DungeonRPG2.D.Scripts.General;

public partial class PlayerAttackState : PlayerState
{
    [Export] private Timer _comboTimerNode;
    
    private int _comboCounter = 1;
    private int _maxComboCount = 2;
    
    public override void _Ready()
    {
        base._Ready();
        
        _comboTimerNode.Timeout += () => _comboCounter = 1;
    }
    protected override void EnterState()
    {
        characterNode.AnimationPlayerNode.Play(GameConstants.ANIM_ATTACK + _comboCounter, -1, 1.5f);

        characterNode.AnimationPlayerNode.AnimationFinished += HandleAnimationFinished;
    }
    
    protected override void ExitState()
    {
        characterNode.AnimationPlayerNode.AnimationFinished -= HandleAnimationFinished;
        _comboTimerNode.Start();
    }

    private void HandleAnimationFinished(StringName animname)
    {
        _comboCounter++;
        _comboCounter = Mathf.Wrap(_comboCounter,1, _maxComboCount + 1);
        
        characterNode.ToggleHitbox(true);
        
        characterNode.StateMachineNode.SwitchState<PlayerIdleState>();
    }

    private void PerformHit()
    {
        Vector3 newPosition = characterNode.SpriteNode.FlipH ? Vector3.Left : Vector3.Right;

        float distanceMultiplier = 0.75f;
        newPosition *= distanceMultiplier;
        
        characterNode.HitboxxNode.Position = newPosition;

        characterNode.ToggleHitbox(false);
    }
}
