using Godot;
using DungeonRPG2.D.Scripts.General;

public partial class PlayerDashState : PlayerState
{
    [Export] private Timer _dashTimerNode;
    [Export] private float _speed = 10;
    
    public override void _Ready()
    {
        base._Ready();
        
        _dashTimerNode.Timeout += HandleDashTimeout;
    }

    public override void _PhysicsProcess(double delta)
    {
        characterNode.MoveAndSlide();
        characterNode.Flip();
    }
    
    private void HandleDashTimeout()
    {
        characterNode.Velocity = Vector3.Zero;
        characterNode.stateMachineNode.SwitchState<PlayerIdleState>();
    }
    
    protected override void EnterState()
    {
        characterNode.animationPlayerNode.Play(GameConstants.ANIM_DASH);
        characterNode.Velocity = new(
            characterNode.direction.X,
            0,
            characterNode.direction.Y
        );
            
        if (characterNode.Velocity == Vector3.Zero)
        {
            characterNode.Velocity = characterNode.spriteNode.FlipH ? Vector3.Left : Vector3.Right;
        }
            
        characterNode.Velocity *= _speed;
        _dashTimerNode.Start();
    }
}
