using UnityEngine;
using UnityEngine.AI;

public class EnemyFSMState_BaseAttack : EnemyFSMState
{
    private Transform _selfTransform;
    private Transform _playerTransform;
    private float _attackRadius;

    public EnemyFSMState_BaseAttack(EnemyFSM FSM) : base(FSM)
    {
        _selfTransform = _FSM.SelfTransform;
        _playerTransform = _FSM.PlayerTransform;
        _attackRadius = _FSM.AgroRadius;
        _attackRadius = _FSM.Enemy.GetComponent<NavMeshAgent>().radius * 1.5f;
    }

    public override void Enter()
    {
        _animatorController.SwitchAnimationTo(EnemyAnimatorController.BASE_ATTACK_ANIM_NAME);
    }

    public override void Exit()
    {
    }

    public override void Update()
    {
        _selfTransform.LookAt(_playerTransform);


        if (Vector3.Distance(_playerTransform.position, _selfTransform.position) > _attackRadius)
            _FSM.SwitchStateTo<EnemyFSMState_Aggro>();
    }
}
