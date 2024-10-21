using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.Timeline;

public class PlayerFSMState_Idle : PlayerFSMState
{
    private PlayerTransformController _transformController;
    private float _movementStopDuration;

    public PlayerFSMState_Idle(PlayerFSM FSM) : base(FSM)
    {
        _transformController = FSM.TransformController;
        _movementStopDuration = 0.3f;
    }

    public override void Enter()
    {
        _transformController.TargetVelocityVector = Vector3.zero;
        _transformController.VelocityTransitionDelta = _transformController.CurrentVelocityVector.magnitude;
        _transformController.VelocityTransitionDuration = _movementStopDuration;

        _FSM.AnimatorController.SwitchAnimationTo("Idle", _movementStopDuration);
        Debug.Log("IdleState");
    }

    public override void Exit()
    {
    }

    public override void Update()
    {
    }

}
