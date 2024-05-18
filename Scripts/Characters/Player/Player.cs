using Godot;
using System;
using DungeonRPG2.D.Scripts.General;

public partial class Player : CharacterBody3D
{
    [ExportGroup("Required Nodes")]
    [Export] private AnimationPlayer _animationPlayerNode;
    [Export] private Sprite3D _spriteNode;
    
    private Vector2 _direction = new();

    public override void _Ready()
    {
        _animationPlayerNode.Play(GameConstants.ANIM_IDLE);
    }

    public override void _PhysicsProcess(double delta)
    {
        Velocity = new (_direction.X, 0, _direction.Y);
        Velocity *= 5;

        MoveAndSlide();
        
        Flip();
    }

    public override void _Input(InputEvent @event)
    {
        _direction = Input.GetVector(
            GameConstants.INPUT_MOVE_LEFT, 
            GameConstants.INPUT_MOVE_RIGHT, 
            GameConstants.INPUT_MOVE_FORWARD, 
            GameConstants.INPUT_MOVE_BACKWARD
        );
        
        if (_direction == Vector2.Zero)
        {
            _animationPlayerNode.Play(GameConstants.ANIM_IDLE);
        }
        else
        {
            _animationPlayerNode.Play(GameConstants.ANIM_MOVE);
        }
        
        
    }

    private void Flip()
    {
        bool isNotMovingHorizontally = Velocity.X == 0;

        if (isNotMovingHorizontally)
        {
            return;
        }
            
        bool isMovingLeft = Velocity.X < 0;
        _spriteNode.FlipH = isMovingLeft;
    }
    
    
    
    
}
