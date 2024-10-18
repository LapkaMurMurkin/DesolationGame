using UnityEngine;

public class UserInput : IContext
{
    public bool IsMoving;
}

public class DashContext : IContext
{
    public bool IsDashPerformed;
}

public class PlayerBootstrap : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;

    void Start()
    {
        FiniteStateMachineBuilder builder = new FiniteStateMachineBuilder();
        ActionMap map =  new ActionMap();
        map.Enable();

        IStateMachine stateMachine = builder
            .AddState(new IdleState())
            .AddState(new MoveState())
            .AddState(new DashState())
            .AddTransition<IdleState, MoveState, UserInput>(ctx => ctx.IsMoving)
            .AddTransition<IdleState, DashState, DashContext>(ctx => ctx.IsDashPerformed)
            .AddTransition<MoveState, DashState, DashContext>(ctx => ctx.IsDashPerformed)
            .AddTransition<MoveState, IdleState, UserInput>(ctx => !ctx.IsMoving)
            .AddTransition<DashState, IdleState, DashContext>(ctx => !ctx.IsDashPerformed)
            .SetFirstState<IdleState>()
            .Build();


        _playerController.Init(stateMachine, map);
    }
}
