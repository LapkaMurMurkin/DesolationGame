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
    }

    public override void Exit()
    {
        _FSM.AnimatorEvents.OnAnimationEnd -= EndCombo;
    }

    private void EndCombo()
    {
        _FSM.SwitchStateTo<PlayerFSMState_Idle>();
    }
}
