using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.Timeline;

public class PlayerFSMState_SwingAttack : PlayerFSMState
{
    public PlayerFSMState_SwingAttack(PlayerFSM FSM) : base(FSM) { }

    public override void Enter()
    {
        _FSM.TargetVelocityVector = Vector3.zero;

        _FSM.AnimatorController.SwitchAnimationTo("SwingAttack", 0f);

        _FSM.PlayerAnimatorEvents.OnAnimationEnd += EndAttack;
    }

    public override void Exit()
    {
        _FSM.PlayerAnimatorEvents.OnAnimationEnd -= EndAttack;
    }

    public override void Update()
    {

    }

    private void EndAttack()
    {
        _FSM.SwitchStateTo<PlayerFSMState_Movement>();
    }
}
