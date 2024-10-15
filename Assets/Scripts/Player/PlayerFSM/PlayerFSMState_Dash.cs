using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Timeline;

public class PlayerFSMState_Dash : PlayerFSMState
{
    public PlayerFSMState_Dash(PlayerFSM FSM) : base(FSM) { }

    public override void Enter()
    {
        _FSM.CurrentVelocityVector = _FSM.Player.transform.forward * _FSM.Speed * _FSM.DashAcceleration;
    }

    public override void Exit()
    {

    }

    public override void Update()
    {
        _FSM.CurrentVelocityVector = Vector3.MoveTowards(_FSM.CurrentVelocityVector, _FSM.TargetVelocityVector, _FSM.Speed * _FSM.DashAcceleration / _FSM.DashDecelerationTime * Time.deltaTime);
        _FSM.Player.gameObject.transform.position += _FSM.CurrentVelocityVector * Time.deltaTime;

        if (_FSM.CurrentVelocityVector == _FSM.TargetVelocityVector)
            _FSM.SwitchStateTo<PlayerFSMState_Movement>();
    }
}
