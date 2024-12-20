using UnityEngine;
using UnityEngine.AI;

public class EnemyFSMState_Aggro : EnemyFSMState
{
    private Transform _selfTransform;
    private Transform _playerTransform;
    private float _agroRadius;
    private float _attackRadius;
    private float _agroTime;
    private float _timer;

    public EnemyFSMState_Aggro(EnemyFSM FSM) : base(FSM)
    {
        _selfTransform = _FSM.SelfTransform;
        _playerTransform = _FSM.PlayerTransform;
        _agroRadius = _FSM.AgroRadius;
        _attackRadius = _FSM.Enemy.GetComponent<NavMeshAgent>().radius * 1.5f;
        _agroTime = 3;
        _timer = 0;
    }

    public override void Enter()
    {
        _timer = 0;
        _animatorController.SwitchAnimationTo(EnemyAnimatorController.RAM_PREPARE_ANIM_NAME);
    }

    public override void Exit()
    {
    }

    public override void Update()
    {
        _selfTransform.LookAt(_playerTransform);

        _timer += Time.deltaTime;

        if (_timer >= _agroTime)
            _FSM.SwitchStateTo<EnemyFSMState_Ram>();

        if (Vector3.Distance(_playerTransform.position, _selfTransform.position) < _attackRadius)
            _FSM.SwitchStateTo<EnemyFSMState_BaseAttack>();

        if (Vector3.Distance(_playerTransform.position, _selfTransform.position) > _agroRadius)
            _FSM.SwitchStateTo<EnemyFSMState_Patrol>();
    }
}
