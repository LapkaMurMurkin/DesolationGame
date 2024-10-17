using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerFSMState_Movement : PlayerFSMState
{
    public PlayerFSMState_Movement(PlayerFSM FSM) : base(FSM) { }

    private InputAction _movement;
    private InputAction _dash;

    public override void Enter()
    {
        _movement = _FSM.Movement;
        _dash = _FSM.Dash;

        _dash.performed += Dash;
        _FSM.Attack.performed += Attack;
        _FSM.Skill_1.performed += Skill_1;
    }

    public override void Exit()
    {
        _dash.performed -= Dash;
        _FSM.Attack.performed -= Attack;
        _FSM.Skill_1.performed -= Skill_1;
    }

    private void Dash(InputAction.CallbackContext context)
    {
        _FSM.SwitchStateTo<PlayerFSMState_Dash>();
    }

    public override void Update()
    {
        _FSM.MovementInput = _movement.ReadValue<Vector2>();
        _FSM.MovementDirection = new Vector3(_FSM.MovementInput.x, 0, _FSM.MovementInput.y);
        _FSM.TargetVelocityVector = _FSM.MovementDirection * _FSM.Speed;

        if (_movement.phase is InputActionPhase.Started)
        {
            _FSM.CurrentVelocityVector = Vector3.MoveTowards(_FSM.CurrentVelocityVector, _FSM.TargetVelocityVector, _FSM.Speed / _FSM.StartTime * Time.deltaTime);
            _FSM.AnimatorController.SwitchAnimationTo("Run", 0.1f);
        }
        else
        {
            _FSM.CurrentVelocityVector = Vector3.MoveTowards(_FSM.CurrentVelocityVector, _FSM.TargetVelocityVector, _FSM.Speed / _FSM.StopTime * Time.deltaTime);
            _FSM.AnimatorController.SwitchAnimationTo("Idle", 0.3f);
        }

        _FSM.Player.gameObject.transform.position += _FSM.CurrentVelocityVector * Time.deltaTime;

        if (_FSM.TargetVelocityVector != Vector3.zero)
            _FSM.Player.gameObject.transform.rotation = Quaternion.RotateTowards(_FSM.Player.gameObject.transform.rotation, Quaternion.LookRotation(_FSM.TargetVelocityVector), 180 / 0.2f * Time.deltaTime);
    }

    private void Attack(InputAction.CallbackContext context)
    {
        _FSM.SwitchStateTo<PlayerFSMState_Attack>();
    }

    private void Skill_1(InputAction.CallbackContext context)
    {
        _FSM.SwitchStateTo<PlayerFSMState_SwingAttack>();
    }
}
