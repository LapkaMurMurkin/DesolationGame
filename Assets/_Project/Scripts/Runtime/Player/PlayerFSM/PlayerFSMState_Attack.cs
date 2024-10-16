using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Timeline;

public class PlayerFSMState_Attack : PlayerFSMState
{
    public PlayerFSMState_Attack(PlayerFSM FSM) : base(FSM) { }

    public override void Enter()
    {
        _FSM.TargetVelocityVector = Vector3.zero;

        Vector3 mouseClickPosition = _FSM.Raycaster.GetWorlPoint();
        _FSM.Player.gameObject.transform.LookAt(mouseClickPosition);

        _FSM.AnimatorController.SwitchAnimationTo("Attack", 0f);

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
