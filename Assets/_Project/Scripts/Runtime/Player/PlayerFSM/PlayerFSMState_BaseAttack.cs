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

    private float _attackDamage;

    public PlayerFSMState_BaseAttack(PlayerFSM FSM) : base(FSM)
    {
        _transformController = FSM.TransformController;
        _stepRange = 1.5f;
        _stepDuration = 0.4f;

        _attackDamage = _FSM.Player._playerStatsInitialization.AttackDamage;
    }

    public override void Enter()
    {
        _FSM.Player.GetComponentInChildren<PlayerBaseAttackCollider>(true).onDummyCollision += DealDamage;
        _FSM.AnimatorEvents.OnAwaitCombo += AwaitCombo;

        _animatorController.SwitchAnimationTo(_animatorController.GetNextAttackInComboSequence(), 0f);

        _transformController.CurrentVelocityVector = Vector3.zero;
        _transformController.AddAcceleration(_stepRange, _stepDuration);
    }

    public override void Exit()
    {
        _FSM.Player.GetComponentInChildren<PlayerBaseAttackCollider>(true).onDummyCollision -= DealDamage;
        _FSM.AnimatorEvents.OnAwaitCombo -= AwaitCombo;
    }

    private void AwaitCombo()
    {
        _FSM.SwitchStateTo<PlayerFSMState_BaseAttackAwaitCombo>();
    }

    private void DealDamage(Dummy dummy)
    {
        Debug.Log($"Dummy damage {_animatorController.BaseAttackComboSequenceIndex * _attackDamage}");
    }
}
