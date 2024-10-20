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
        Debug.Log("IdleState");
    }

    public override void Exit()
    {
    }

    public override void Update()
    {

    }

}
