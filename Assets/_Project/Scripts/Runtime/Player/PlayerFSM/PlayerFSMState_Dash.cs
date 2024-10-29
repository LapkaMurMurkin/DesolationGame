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
        _dashRange = 5f;
        _dashDuration = 0.5f;
    }

    public override void Enter()
    {
        _timer = _dashDuration;
        _animatorController.SwitchAnimationTo("Dash");
        _transformController.AddAcceleration(_dashRange, _dashDuration);
    }

    public override void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0)
            _FSM.SwitchStateTo<PlayerFSMState_Movement>();
    }
}
