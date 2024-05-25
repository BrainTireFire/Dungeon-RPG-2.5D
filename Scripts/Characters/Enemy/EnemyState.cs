using DungeonRPG2.D.Scripts.Characters;
using Godot;

public abstract partial class EnemyState : CharacterState
{
    protected Vector3 _destination;

    protected Vector3 GetPointGlobalPosition(int index)
    {
        Vector3 localPos = characterNode.PathNode.Curve.GetPointPosition(index);
        Vector3 globalPos = characterNode.PathNode.GlobalPosition; 
        return globalPos + localPos;
    }
    
    protected void Move()
    {
        characterNode.AgentNode.GetNextPathPosition();
        characterNode.Velocity = characterNode.GlobalPosition.DirectionTo(_destination);
        
        characterNode.MoveAndSlide();
        characterNode.Flip();
    }
    
    protected void HandleChaseAreaBodyEntered(Node3D body)
    {
        characterNode.StateMachineNode.SwitchState<EnemyChaseState>();
    }
}