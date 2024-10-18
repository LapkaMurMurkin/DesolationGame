public class FiniteStateMachine : IStateMachine, IStateChanger
{
    private IState _currentState;
    private IState _firstState;

    public IState CurrentState => _currentState;

    public void SetFirstState(IState firstState)
    {
        _firstState = firstState ?? throw new System.ArgumentNullException(nameof(firstState));
        _currentState = _firstState;
    }

    public void Run()
    {
        _currentState?.Enter();
    }

    public void Stop()
    {
        _currentState.Exit();
    }

    public void Update()
    {
        _currentState?.Update();
    }

    public void ChangeState(IState nextState)
    {
        _currentState?.Exit();
        _currentState = nextState;
        _currentState.Enter();
    }

    public void Apply(IContext context)
    {
        _currentState?.Apply(this, context);
    }
}
