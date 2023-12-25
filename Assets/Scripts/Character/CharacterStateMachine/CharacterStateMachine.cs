using System.Collections.Generic;
using System.Linq;

public class CharacterStateMachine : IStateSwitcher
{
    public readonly StateMachineData Data;
    private List<IState> _states;
    private IState _currentState;
    
    public CharacterStateMachine(Character character)
    {
        Data = new StateMachineData();

        _states = new List<IState>()
        {
            new IdlingState(this, Data, character),
            new WalkingState(this, Data, character),
            new RunningState(this, Data, character),
            new JumpingState(this, Data, character),
            new FallingState(this, Data, character),
            new SlideOnWallState(this, Data, character),
        };

        _currentState = _states[0];
        _currentState.Enter();
    }

    public void SwitchState<State>() where State : IState
    {
        IState state = _states.FirstOrDefault(state => state is State);

        _currentState.Exit();
        _currentState = state;
        _currentState.Enter();
    }

    public void HandleInput() => _currentState.HandleInput();

    public void Update() => _currentState.Update();

    public void FixedUpdate() => _currentState.FixedUpdate();
}