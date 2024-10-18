public interface IState
{
    void Enter();
    void Exit();
    void Update(); // maybe as parametr StateChanger in future
    void Apply(IStateChanger stateChanger, IContext context);
}
