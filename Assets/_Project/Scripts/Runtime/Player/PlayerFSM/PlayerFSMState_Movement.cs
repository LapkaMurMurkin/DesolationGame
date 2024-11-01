using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerFSMState_Movement : PlayerFSMState
{
    private InputAction _movement;
    private Vector2 _movementInput;
    private Vector3 _movementDirection;
    private float _movementSpeed;
    private float _movementStartDuration;

    public PlayerFSMState_Movement(PlayerFSM FSM) : base(FSM)
    {
        _movement = ServiceLocator.Get<ActionMap>().Player.Movement;
        _movementInput = new Vector2();
        _movementDirection = new Vector3();
        _movementSpeed = _FSM.Model.Stats[StatID.MOVEMENT_SPEED].ModifiedValue.CurrentValue;
        _movementStartDuration = 0.1f;
    }

    public override void Enter()
    {
        _transformController.VelocityTransitionDelta = _movementSpeed;
        _transformController.VelocityTransitionDuration = _movementStartDuration;

        _FSM.AnimatorController.SwitchAnimationTo("Run", _movementStartDuration);
    }

    public override void Exit()
    {
    }

    public override void Update()
    {
        _movementInput = _movement.ReadValue<Vector2>();
        if (_movementInput == Vector2.zero)
        {
            _FSM.SwitchStateTo<PlayerFSMState_Idle>();
            return;
        }

        _movementDirection = new Vector3(_movementInput.x, 0, _movementInput.y);
        _transformController.TargetVelocityVector = _movementDirection * _movementSpeed;
    }

}
