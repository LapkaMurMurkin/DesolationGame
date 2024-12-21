using UnityEngine;
using UnityEngine.AI;

public class EnemyFSMState_BaseAttack : EnemyFSMState
{
    private Transform _selfTransform;
    private Transform _playerTransform;

    private float _attackRadius;

    private NavMeshAgent _navMeshAgent;

    public EnemyFSMState_BaseAttack(EnemyFSM FSM) : base(FSM)
    {
        _selfTransform = _FSM.SelfTransform;
        _playerTransform = _FSM.PlayerTransform;

        _attackRadius = _FSM.AttackRadius;

        _navMeshAgent = _FSM.Enemy.GetComponent<NavMeshAgent>();
    }

    public override void Enter()
    {
        _animatorController.SwitchAnimationTo(EnemyAnimatorController.BASE_ATTACK_ANIM_NAME);
        Debug.Log("enter");
    }

    public override void Exit()
    {
        Debug.Log("exit");

    }

    public override void Update()
    {
        _selfTransform.LookAt(_playerTransform);

        if (Vector3.Distance(_playerTransform.position, _selfTransform.position) > _attackRadius)
        {
            _navMeshAgent.Move((_playerTransform.position - _selfTransform.position) * 2 * Time.deltaTime);
            _animatorController.SwitchAnimationTo(EnemyAnimatorController.WALK_ANIM_NAME);
        }
        else
        {
            _animatorController.SwitchAnimationTo(EnemyAnimatorController.BASE_ATTACK_ANIM_NAME);
        }

        /*         if (Vector3.Distance(_playerTransform.position, _selfTransform.position) > _attackRadius)
                    _FSM.SwitchStateTo<EnemyFSMState_Aggro>(); */
    }
}
