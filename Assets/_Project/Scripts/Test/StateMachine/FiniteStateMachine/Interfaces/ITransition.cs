public interface ITransition
{
    IState NextState { get; }
    bool CanTransit(IContext context);
}
