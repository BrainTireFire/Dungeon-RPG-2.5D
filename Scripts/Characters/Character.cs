using Godot;

namespace DungeonRPG2.D.Scripts.Characters;

public abstract partial class Character : CharacterBody3D
{
    [ExportGroup("Required Nodes")]
    [Export] public AnimationPlayer AnimationPlayerNode { get; private set; }
    [Export] public Sprite3D SpriteNode { get; private set; }
    [Export] public StateMachine StateMachineNode { get; private set; }
    
    public Vector2 direction = new();
    
    public void Flip()
    {
        bool isNotMovingHorizontally = Velocity.X == 0;

        if (isNotMovingHorizontally)
        {
            return;
        }
            
        bool isMovingLeft = Velocity.X < 0;
        SpriteNode.FlipH = isMovingLeft;
    }
}