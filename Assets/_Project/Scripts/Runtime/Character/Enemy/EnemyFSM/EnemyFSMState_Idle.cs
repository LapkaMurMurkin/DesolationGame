using UnityEngine;

public class EnemyFSMState_Idle : EnemyFSMState
{
    private float _idleTime;
    private float _timer;

    public EnemyFSMState_Idle(EnemyFSM FSM) : base(FSM)
    {
    }

    public override void Enter()
    {
        _animatorController.SwitchAnimationTo(EnemyAnimatorController.IDLE_ANIM_NAME);
        _idleTime = 3f;
        _timer = 0;
    }

    public override void Exit()
    {
    }

    public override void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _idleTime)
            _FSM.SwitchStateTo<EnemyFSMState_Patrol>();
    }
}
