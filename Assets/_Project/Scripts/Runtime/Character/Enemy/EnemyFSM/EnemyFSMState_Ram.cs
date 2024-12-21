using System;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFSMState_Ram : EnemyFSMState
{
    private Player _player;

    private Transform _selfTransform;
    private Transform _playerTransform;

    private NavMeshAgent _navMeshAgent;

    private float _defaultSpeed;
    private float _defaultAcceleration;
    private float _ramSpeed;
    private float _ramAcceleration;

/*     private EnemyWeapon _enemyWeapon; */

    public EnemyFSMState_Ram(EnemyFSM FSM) : base(FSM)
    {
        _player = ServiceLocator.Get<Player>();

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
        if (Vector3.Distance(_selfTransform.position, _playerTransform.position) < 2)
            DealDamage(_player);

        if (_navMeshAgent.hasPath is false)
        {
            _FSM.SwitchStateTo<EnemyFSMState_Aggro>();
        }
    }

    private void DealDamage(Player player)
    {
        player.ApplyDamage(10);
        _navMeshAgent.ResetPath();
        _navMeshAgent.velocity = Vector3.zero;
        _FSM.SwitchStateTo<EnemyFSMState_BaseAttack>();
    }
}
