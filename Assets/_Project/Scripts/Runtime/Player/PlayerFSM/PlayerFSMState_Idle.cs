using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.Timeline;

public class PlayerFSMState_Idle : PlayerFSMState
{
    private float _movementStopDuration;

    private List<string> _idleAnimations;

    public PlayerFSMState_Idle(PlayerFSM FSM) : base(FSM)
    {
        _movementStopDuration = 0.3f;

        _idleAnimations = new List<string>{
            {PlayerAnimatorController.IDLE_ANIM_NAME},
            {PlayerAnimatorController.BASE_ATTACK_END_1_ANIM_NAME},
            {PlayerAnimatorController.BASE_ATTACK_END_2_ANIM_NAME},
            {PlayerAnimatorController.BASE_ATTACK_END_3_ANIM_NAME}
        };
    }

    public override void Enter()
    {
        _transformController.TargetVelocityVector = Vector3.zero;
        _transformController.VelocityTransitionDelta = _transformController.CurrentVelocityVector.magnitude;
        _transformController.VelocityTransitionDuration = _movementStopDuration;

        _FSM.AnimatorController.SwitchAnimationTo("Idle", _movementStopDuration);
    }

    public override void Exit()
    {
    }

    public override void Update()
    {
    }

}
