public interface IStateMachine : IUpdatable
{
    IState CurrentState { get; }
    void Run();
    void Stop(); 
    void SetFirstState(IState firstState);
    void Apply(IContext context);
}
