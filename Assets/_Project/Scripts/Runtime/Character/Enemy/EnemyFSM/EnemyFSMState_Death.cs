using UnityEngine;

public class EnemyFSMState_Death : EnemyFSMState
{
    public EnemyFSMState_Death(EnemyFSM FSM) : base(FSM)
    {
    }

    public override void Enter()
    {
        _animatorController.SwitchAnimationTo(EnemyAnimatorController.DEATH_ANIM_NAME);

        Debug.Log("Enemy is dead.");
    }

    public override void Exit()
    {
    }

    public override void Update()
    {
    }
}
