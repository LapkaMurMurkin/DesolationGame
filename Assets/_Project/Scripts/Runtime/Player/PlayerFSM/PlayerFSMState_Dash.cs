using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Timeline;

public class PlayerFSMState_Dash : PlayerFSMState
{
    private float _dashRange;
    private float _dashDuration;
    private float _timer;

    public PlayerFSMState_Dash(PlayerFSM FSM) : base(FSM)
    {
        _dashRange = _FSM.Model.PlayerDefaultInitialization.DashRange;
        _dashDuration = _FSM.Model.PlayerDefaultInitialization.DashDuration;
    }

    public override void Enter()
    {
        _FSM.Player.isInvulnerable = true;
        _timer = _dashDuration;
        _animatorController.SwitchAnimationTo("Dash");
        _transformController.AddAcceleration(_dashRange, _dashDuration);
    }

    public override void Exit()
    {
        _FSM.Player.isInvulnerable = false;
    }

    public override void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0)
            _FSM.SwitchStateTo<PlayerFSMState_Movement>();
    }
}
