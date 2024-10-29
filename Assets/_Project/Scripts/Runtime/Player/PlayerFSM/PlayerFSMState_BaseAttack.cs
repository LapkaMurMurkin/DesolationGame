using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Timeline;

public class PlayerFSMState_BaseAttack : PlayerFSMState
{
    private float _attackDamage;

    private float _stepRange;
    private float _stepDuration;

    public PlayerFSMState_BaseAttack(PlayerFSM FSM) : base(FSM)
    {
        _attackDamage = _FSM.Player._playerStatsInitialization.BaseDamage;

        _transformController = FSM.TransformController;
        _stepRange = 1.5f;
        _stepDuration = 0.4f;
    }

    public override void Enter()
    {
        _FSM.Player.GetComponentInChildren<PlayerBaseAttackCollider>(true).onAgentDamageableCollision += DealDamage;
        _FSM.AnimatorEvents.OnAwaitCombo += AwaitCombo;

        MakeAttack();
    }

    public override void Exit()
    {
        _FSM.Player.GetComponentInChildren<PlayerBaseAttackCollider>(true).onAgentDamageableCollision -= DealDamage;
        _FSM.AnimatorEvents.OnAwaitCombo -= AwaitCombo;
    }

    private void MakeAttack()
    {
        _animatorController.SwitchAnimationTo(_animatorController.GetNextAttackInComboSequence(), 0f);

        _transformController.CurrentVelocityVector = Vector3.zero;
        _transformController.AddAcceleration(_stepRange, _stepDuration);
    }

    private void AwaitCombo()
    {
        _FSM.SwitchStateTo<PlayerFSMState_BaseAttackAwaitCombo>();
    }

    private void DealDamage(AgentDamageable agentDamageable)
    {
        agentDamageable.ApplyDamage(69);
        Debug.Log(agentDamageable + " agentDamageable damage 69");
        //Debug.Log($"Dummy damage {_animatorController.BaseAttackComboSequenceIndex * _attackDamage}");
    }
}
