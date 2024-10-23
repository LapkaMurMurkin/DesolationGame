using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Timeline;

public class PlayerFSMState_BaseAttack : PlayerFSMState
{
    private PlayerTransformController _transformController;
    private float _stepRange;
    private float _stepDuration;

    public PlayerFSMState_BaseAttack(PlayerFSM FSM) : base(FSM)
    {
        _transformController = FSM.TransformController;
        _stepRange = 1f;
        _stepDuration = 0.2f;
    }

    public override void Enter()
    {
        _FSM.AnimatorEvents.OnAnimationEnd += AwaitCombo;

        _animatorController.SwitchAnimationTo(_animatorController.GetNextAttackInComboSequence(), 0f);

        _transformController.CurrentVelocityVector = Vector3.zero;
        _transformController.AddAcceleration(_stepRange, _stepDuration);

        Debug.Log("AttackState");
    }

    public override void Exit()
    {
        _FSM.AnimatorEvents.OnAnimationEnd -= AwaitCombo;
    }

    private void AwaitCombo()
    {
        _FSM.SwitchStateTo<PlayerFSMState_BaseAttackAwaitCombo>();
    }
}
