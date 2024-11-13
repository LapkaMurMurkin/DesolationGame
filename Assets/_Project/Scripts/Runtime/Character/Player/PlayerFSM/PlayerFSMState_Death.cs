using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Timeline;

public class PlayerFSMState_Death : PlayerFSMState
{


    public PlayerFSMState_Death(PlayerFSM FSM) : base(FSM)
    {

    }

    public override void Enter()
    {
        _transformController.TargetVelocityVector = Vector3.zero;
        _transformController.VelocityTransitionDelta = _transformController.CurrentVelocityVector.magnitude;
        _transformController.VelocityTransitionDuration = 0.5f;

        _animatorController.SwitchAnimationTo(PlayerAnimatorController.DEATH_ANIM_NAME);

        Debug.Log("Player is dead...");
    }

    public override void Exit()
    {

    }

    public override void Update()
    {

    }
}
