using Godot;
using System.Linq;
using DungeonRPG2.D.Scripts.General;

public partial class StateMachine : Node
{
    [Export] private Node _currentState;
    private Node _previousState;
    [Export] private Node[] _states;

    public override void _Ready()
    {
        _currentState.Notification(GameConstants.NOTIFICATION_ENTER_STATE);
    }

    public void SwitchState<T>()
    {
        Node newState = _states.FirstOrDefault(state => state is T);
        
        if (newState == null)  
        {
            return;
        }

        if (_currentState is T)
        {
            return;
        }
        
        // Notify to disable node phyciscs process
        _currentState.Notification(GameConstants.NOTIFICATION_EXIT_STATE);
        
        _previousState = _currentState;
        _currentState = newState;
        
        _currentState.Notification(GameConstants.NOTIFICATION_ENTER_STATE);
    }
}
