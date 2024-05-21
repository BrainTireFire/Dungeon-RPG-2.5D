using Godot;
using System;

public partial class StateMachine : Node
{
    [Export] private Node _currentState;
    private Node _previousState;
    [Export] private Node[] _states;

    public override void _Ready()
    {
        _currentState.Notification(5001);
    }

    public void SwitchState<T>()
    {
        Node newState = null;

        foreach (Node state in _states)
        {
            if (state is T)
            {
                newState = state;
            }
        }

        if (newState == null)  
        {
            GD.PrintErr(GetType().Name + "newState not found.");
            return;
        }
        
        // Notify to disable node phyciscs process
        _currentState.Notification(5002);
        
        _previousState = _currentState;
        _currentState = newState;
        
        _currentState.Notification(5001);
    }
}
