using System;
using System.Collections.Generic;

public class FiniteStateMachineBuilder
{
    private Dictionary<string, BaseState> _states = new();
    private FiniteStateMachine _finiteStateMachine;

    public FiniteStateMachineBuilder()
    {
        Clear();
    }

    public void Clear()
    {
        _states.Clear();
        _finiteStateMachine = new();
    }

    public FiniteStateMachineBuilder AddState<T>(T state) where T : BaseState
    {
        _states[typeof(T).Name] = state;

        return this;
    }

    public FiniteStateMachineBuilder AddTransition<TFrom, TTo, TContext>(Func<TContext, bool> condition)
        where TFrom : BaseState
        where TTo : BaseState
        where TContext : IContext
    {
        string from = typeof(TFrom).Name;
        string to = typeof(TTo).Name;

        if(_states.TryGetValue(from, out BaseState fromState) == false)
            throw new ArgumentException($"State {from} not found");

        if(_states.TryGetValue(to, out BaseState toState) == false) 
            throw new ArgumentException($"State {to} not found");
        
        fromState.AddTransition(new Transition<TContext>(toState, condition));
        return this;
    }

    public FiniteStateMachineBuilder SetFirstState<T>() where T : BaseState
    {
        if(_states.TryGetValue(typeof(T).Name, out BaseState firstState) == false) 
            throw new ArgumentException($"State {typeof(T).Name} not found");
        
        _finiteStateMachine.SetFirstState(firstState);

        return this;
    }

    public IStateMachine Build() 
    {
        IStateMachine stateMachine = _finiteStateMachine;
        Clear();

        return stateMachine;
    }
}
