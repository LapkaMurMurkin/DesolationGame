using System.Diagnostics;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFSMState_Ram : EnemyFSMState
{
    private Transform _selfTransform;
    private Transform _playerTransform;

    private NavMeshAgent _navMeshAgent;

    private float _defaultSpeed;
    private float _defaultAcceleration;
    private float _ramSpeed;
    private float _ramAcceleration;


    public EnemyFSMState_Ram(EnemyFSM FSM) : base(FSM)
    {
        _selfTransform = _FSM.SelfTransform;
        _playerTransform = _FSM.PlayerTransform;

        _navMeshAgent = _FSM.Enemy.GetComponent<NavMeshAgent>();

        _defaultSpeed = _navMeshAgent.speed;
        _defaultAcceleration = _navMeshAgent.acceleration;
        _ramSpeed = 10;
        _ramAcceleration = _ramSpeed * 10;
    }

    public override void Enter()
    {
        _navMeshAgent.speed = _ramSpeed;
        _navMeshAgent.acceleration = _ramAcceleration;
        _navMeshAgent.SetDestination(_playerTransform.position);
        _animatorController.SwitchAnimationTo(EnemyAnimatorController.RAM_ANIM_NAME);
    }

    public override void Exit()
    {
        _navMeshAgent.speed = _defaultSpeed;
        _navMeshAgent.acceleration = _defaultAcceleration;
    }

    public override void Update()
    {
        if (_navMeshAgent.hasPath is false)
        {
            _FSM.SwitchStateTo<EnemyFSMState_Aggro>();
        }
    }
}
