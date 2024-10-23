using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Timeline;

public class PlayerFSMState_BaseAttackAwaitCombo : PlayerFSMState
{
    public PlayerFSMState_BaseAttackAwaitCombo(PlayerFSM FSM) : base(FSM)
    {

    }

    public override void Enter()
    {
        _FSM.AnimatorEvents.OnAnimationEnd += EndCombo;

        _animatorController.SwitchAnimationTo(_animatorController.GetNextAttackInComboSequence(), 0f);
    }

    public override void Exit()
    {
        _FSM.AnimatorEvents.OnAnimationEnd -= EndCombo;
    }

    private void EndCombo()
    {
        _FSM.SwitchStateTo<PlayerFSMState_Idle>();
        _animatorController.SwitchAnimationTo(PlayerAnimatorController.BASE_ATTACK_END_3_ANIM_NAME);
    }

    /*     public override void Update()
        {
            _comboAttackTimer -= Time.deltaTime;

            if (_comboAttackTimer <= 0)
                _FSM.SwitchStateTo<PlayerFSMState_Movement>();

        } */
}
