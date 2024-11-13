using UnityEngine;
using UnityEngine.AI;

public class EnemyFSMState_Aggro : EnemyFSMState
{
    private NavMeshAgent _navMeshAgent;
    private Transform _enemyTransform;
    private Transform _playerTransform;
    private float _aggroRadius;

    public EnemyFSMState_Aggro(EnemyFSM FSM) : base(FSM)
    {
        _navMeshAgent = _FSM.Enemy.GetComponent<NavMeshAgent>();
        _enemyTransform = _FSM.Enemy.transform;
        _playerTransform = ServiceLocator.Get<Player>().transform;
        _aggroRadius = 5;
    }

    public override void Enter()
    {

    }

    public override void Exit()
    {
    }

    public override void Update()
    {
        _navMeshAgent.SetDestination(_playerTransform.position);

        float distanceToPlayer = Vector3.Distance(_playerTransform.position, _enemyTransform.position);

        if (distanceToPlayer > _aggroRadius)
            _FSM.SwitchStateTo<EnemyFSMState_Patrol>();
    }
}
