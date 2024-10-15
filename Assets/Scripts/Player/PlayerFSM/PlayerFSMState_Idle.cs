using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.Timeline;

public class PlayerFSMState_Idle : PlayerFSMState
{
    public PlayerFSMState_Idle(PlayerFSM FSM) : base(FSM) { }

    public override void Enter()
    {
        _FSM.Movement.performed += Move;
        _FSM.Dash.performed += Dash;
        _FSM.Attack.performed += Attack;
    }

    public override void Exit()
    {
        _FSM.Movement.performed -= Move;
        _FSM.Dash.performed -= Dash;
        _FSM.Attack.performed -= Attack;
    }

    public override void Update()
    {

    }

    private void Move(InputAction.CallbackContext context)
    {
        Debug.Log("Move");
        _FSM.SwitchStateTo<PlayerFSMState_Movement>();
    }

    private void Dash(InputAction.CallbackContext context)
    {
        Debug.Log("Dash");
        _FSM.SwitchStateTo<PlayerFSMState_Dash>();

    }
    private void Attack(InputAction.CallbackContext context)
    {
        Debug.Log("Attack");

    }
}
