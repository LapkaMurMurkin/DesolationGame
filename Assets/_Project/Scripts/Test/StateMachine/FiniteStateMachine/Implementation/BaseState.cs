using System;
using System.Collections.Generic;

public class BaseState : IState
{
    private List<ITransition> _transitions = new(3); // 3 for test 

    public void AddTransition(ITransition transition)
    {
        if (transition == null)
            throw new ArgumentNullException(nameof(transition));

        _transitions.Add(transition);
    }

    public virtual void Enter()
    {
    }

    public virtual void Exit()
    {
    }

    public virtual void Update()
    {
    }

    public void Apply(IStateChanger stateChanger, IContext context)
    {
        if(TryGetNewState(context, out IState nextState))
            stateChanger.ChangeState(nextState);
    }

    private bool TryGetNewState(IContext context, out IState nextState)
    {
        nextState = null;

        foreach (var transition in _transitions)
        {
            if(transition.CanTransit(context))
            {
                nextState = transition.NextState;
                break;
            }    
        }

        return nextState != null;
    }
}
