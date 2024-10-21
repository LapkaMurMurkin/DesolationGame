using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Timeline;

public class PlayerFSMState_BaseAttackAwaitCombo : PlayerFSMState
{
    private float _comboAttackDelay;
    private float _comboAttackTimer;

    public PlayerFSMState_BaseAttackAwaitCombo(PlayerFSM FSM) : base(FSM)
    {
        _comboAttackDelay = 0.5f;
        _comboAttackTimer = _comboAttackDelay;
    }

    public override void Enter()
    {
        _comboAttackTimer = _comboAttackDelay;
    }

    public override void Exit()
    {

    }

    public override void Update()
    {
        _comboAttackTimer -= Time.deltaTime;

        if (_comboAttackTimer <= 0)
            _FSM.SwitchStateTo<PlayerFSMState_Movement>();

    }
}
