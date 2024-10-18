using System;

public class Transition<T> : ITransition where T : IContext
{
    private readonly Func<T, bool> _condition;

    public Transition(IState nextState, Func<T, bool> condition)
    {
        NextState = nextState ?? throw new ArgumentNullException(nameof(nextState));
        _condition = condition ?? throw new ArgumentNullException(nameof(condition));
    }

    public IState NextState { get; }
    
    public bool CanTransit(IContext context)
    {
        if(context is not T tContext)
            return false;
        
        return _condition.Invoke(tContext);
    }
}
