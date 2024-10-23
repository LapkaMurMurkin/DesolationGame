using System.Collections;
using System.Collections.Generic;
using R3;
using UnityEngine;

public abstract class PlayerFSMState : FSMState
{
    protected PlayerFSM _FSM;
    protected PlayerAnimatorController _animatorController;

    public PlayerFSMState(PlayerFSM FSM) : base()
    {
        _FSM = FSM;
        _animatorController = _FSM.AnimatorController;
    }
}