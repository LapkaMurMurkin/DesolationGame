using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFSMState_Patrol : EnemyFSMState
{
    private Transform _selfTransform;
    private Transform _playerTransform;

    private float _movementSpeed;
    private float _movementStartDuration;

    private float _idleTime;
    private float _timer;

    private float _agroRadius;

    private Transform _spawnZoneTransform;
    private float _spawnZoneRadius;

    private NavMeshAgent _navMeshAgent;

    public EnemyFSMState_Patrol(EnemyFSM FSM) : base(FSM)
    {
        _selfTransform = _FSM.SelfTransform;
        _playerTransform = _FSM.PlayerTransform;

        _movementSpeed = 2;
        _movementStartDuration = 0.5f;

        _idleTime = 3f;
        _timer = 0;

        _agroRadius = _FSM.AgroRadius;

        _spawnZoneTransform = _FSM.SpawnZoneTransform;
        _spawnZoneRadius = _spawnZoneTransform.localScale.x;

        _navMeshAgent = _FSM.Enemy.GetComponent<NavMeshAgent>();

        _navMeshAgent.speed = _movementSpeed;
        _navMeshAgent.acceleration = _movementSpeed / _movementStartDuration;
    }

    public override void Enter()
    {
        _animatorController.SwitchAnimationTo(EnemyAnimatorController.IDLE_ANIM_NAME);
    }

    public override void Exit()
    {
        _navMeshAgent.ResetPath();
    }

    public override void Update()
    {
        if (_navMeshAgent.hasPath is false)
        {
            _animatorController.SwitchAnimationTo(EnemyAnimatorController.IDLE_ANIM_NAME);
            _timer += Time.deltaTime;

            if (_timer >= _idleTime)
            {
                GoToRandomPositionInZone();
                _timer = 0;
            }
        }

        if (Vector3.Distance(_selfTransform.position, _playerTransform.position) < _agroRadius)
            _FSM.SwitchStateTo<EnemyFSMState_Aggro>();
    }

    private void GoToRandomPositionInZone()
    {
        Vector3 position = _spawnZoneTransform.position + Random.onUnitSphere * _spawnZoneRadius;
        position.y = 0;

        _animatorController.SwitchAnimationTo(EnemyAnimatorController.WALK_ANIM_NAME);
        _navMeshAgent.SetDestination(position);
    }
}
