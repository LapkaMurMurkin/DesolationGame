using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.Timeline;

public class PlayerFSMState_SwingAttack : PlayerFSMState
{
    private InputAction _movement;
    private Vector2 _movementInput;
    private Vector3 _movementDirection;
    private float _movementSpeed;
    private float _movementStartDuration;

    public PlayerFSMState_SwingAttack(PlayerFSM FSM) : base(FSM)
    {
        _movement = ServiceLocator.Get<ActionMap>().Player.Movement;
        _movementInput = new Vector2();
        _movementDirection = new Vector3();
        _movementSpeed = 2.5f;
        _movementStartDuration = 0.5f;
    }

    public override void Enter()
    {
        //_FSM.TargetVelocityVector = Vector3.zero;
        _transformController.VelocityTransitionDelta = _movementSpeed;
        _transformController.VelocityTransitionDuration = _movementStartDuration;

        _FSM.AnimatorController.SwitchAnimationTo("SwingAttack", 0f);

        _FSM.AnimatorEvents.OnAnimationEnd += EndAttack;
    }

    public override void Exit()
    {
        _FSM.AnimatorEvents.OnAnimationEnd -= EndAttack;
    }

    public override void Update()
    {
        _movementInput = _movement.ReadValue<Vector2>();

        _movementDirection = new Vector3(_movementInput.x, 0, _movementInput.y);
        _transformController.TargetVelocityVector = _movementDirection * _movementSpeed;
    }

    private void EndAttack()
    {
        _FSM.SwitchStateTo<PlayerFSMState_Idle>();
    }
}
