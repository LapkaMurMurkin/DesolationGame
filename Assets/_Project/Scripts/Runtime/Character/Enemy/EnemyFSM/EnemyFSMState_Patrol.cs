using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFSMState_Patrol : EnemyFSMState
{
    private Transform _spawnZoneTransform;
    private float _spawnZoneRadius;

    private float _movementSpeed;
    private float _movementStartDuration;

    private NavMeshAgent _navMeshAgent;

    public EnemyFSMState_Patrol(EnemyFSM FSM) : base(FSM)
    {
        _spawnZoneTransform = _FSM.SpawnZoneTransform;
        _spawnZoneRadius = _spawnZoneTransform.localScale.x;

        _movementSpeed = 2;
        _movementStartDuration = 0.5f;

        _navMeshAgent = _FSM.Enemy.GetComponent<NavMeshAgent>();

        _navMeshAgent.speed = _movementSpeed;
        _navMeshAgent.acceleration = _movementSpeed / _movementStartDuration;
    }

    public override void Enter()
    {
        GoToRandomPositionInZone();
    }

    public override void Exit()
    {
    }

    public override void Update()
    {
        if (_navMeshAgent.hasPath is false)
        {
            _FSM.SwitchStateTo<EnemyFSMState_Idle>();
        }
        /*         if (_navMeshAgent.hasPath is false)
                {
                    _idleTimer -= Time.deltaTime;
                    if (_idleTimer <= 0)
                        GoToRandomPositionInZone();
                }
                else
                    _idleTimer = _idleDuration;

                float distanceToPlayer = Vector3.Distance(_playerTransform.position, _enemyTransform.position); */

        /*         if (distanceToPlayer <= _aggroRadius)
                    _FSM.SwitchStateTo<EnemyFSMState_Aggro>(); */
    }

    private void GoToRandomPositionInZone()
    {
        Vector3 position = _spawnZoneTransform.position + Random.onUnitSphere * _spawnZoneRadius;
        position.y = 0;

        _animatorController.SwitchAnimationTo(EnemyAnimatorController.WALK_ANIM_NAME);
        _navMeshAgent.SetDestination(position);
    }
}
