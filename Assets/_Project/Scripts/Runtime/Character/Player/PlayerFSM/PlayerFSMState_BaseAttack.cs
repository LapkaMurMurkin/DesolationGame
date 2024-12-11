using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Timeline;

public class PlayerFSMState_BaseAttack : PlayerFSMState
{
<<<<<<< Updated upstream
    private InputAction _movement;

    private float _attackDamage;
=======
    private float _attackDamage;

>>>>>>> Stashed changes
    private float _stepRange;
    private float _stepDuration;

    public PlayerFSMState_BaseAttack(PlayerFSM FSM) : base(FSM)
    {
<<<<<<< Updated upstream
        _movement = ServiceLocator.Get<ActionMap>().Player.Movement;

        _animatorController.SetAtackSpeed(_FSM.Model.PlayerDefaultInitialization.BaseAttackSpeed);
        _attackDamage = _FSM.Model.PlayerDefaultInitialization.BaseAttackDamage;
        _stepRange = _FSM.Model.PlayerDefaultInitialization.BaseAttackStepRange;
        _stepDuration = _FSM.Model.PlayerDefaultInitialization.BaseAttackStepDuration;
=======
        _attackDamage = _FSM.Player._playerStatsInitialization.BaseDamage;

        _transformController = FSM.TransformController;
        _stepRange = 1.5f;
        _stepDuration = 0.4f;
>>>>>>> Stashed changes
    }

    public override void Enter()
    {
<<<<<<< Updated upstream
        _FSM.Player.GetComponentInChildren<PlayerWeapon>(true).onEnemyCollision += DealDamage;
        _FSM.AnimatorEvents.OnAwaitCombo += AwaitCombo;
        _FSM.AnimatorEvents.OnAnimationEnd += EndCombo;
=======
        _FSM.Player.GetComponentInChildren<PlayerBaseAttackCollider>(true).onAgentDamageableCollision += DealDamage;
        _FSM.AnimatorEvents.OnAwaitCombo += AwaitCombo;
>>>>>>> Stashed changes

        MakeAttack();
    }

    public override void Exit()
    {
<<<<<<< Updated upstream
        _FSM.Player.GetComponentInChildren<PlayerWeapon>(true).onEnemyCollision -= DealDamage;
        _FSM.AnimatorEvents.OnAwaitCombo -= AwaitCombo;
        _FSM.AnimatorEvents.OnAnimationEnd -= EndCombo;
=======
        _FSM.Player.GetComponentInChildren<PlayerBaseAttackCollider>(true).onAgentDamageableCollision -= DealDamage;
        _FSM.AnimatorEvents.OnAwaitCombo -= AwaitCombo;
>>>>>>> Stashed changes
    }

    private void MakeAttack()
    {
        _animatorController.SwitchAnimationTo(_animatorController.GetNextAttackInComboSequence(), 0f);

<<<<<<< Updated upstream
        Vector2 movementInput = _movement.ReadValue<Vector2>();
        Vector3 attackDirection = new Vector3(movementInput.x, 0, movementInput.y);
        if (attackDirection == Vector3.zero) attackDirection = _transformController.ObjectTransform.forward;
        _transformController.ObjectTransform.rotation = Quaternion.LookRotation(attackDirection);

        _transformController.CurrentVelocityVector = Vector3.zero;
        _transformController.AddStraightAcceleration(_stepRange, _stepDuration);
    }

    private void DealDamage(Enemy enemy)
    {
        Object.Destroy(enemy.gameObject);
        _FSM.Model.Experience.Value += 50;
        Debug.Log("Kill +XP");
=======
        _transformController.CurrentVelocityVector = Vector3.zero;
        _transformController.AddAcceleration(_stepRange, _stepDuration);
>>>>>>> Stashed changes
    }

    private void AwaitCombo()
    {
<<<<<<< Updated upstream
        //MakeAttack();
        _FSM.SwitchStateTo<PlayerFSMState_BaseAttackAwaitCombo>();
    }

    private void EndCombo()
    {
        _FSM.SwitchStateTo<PlayerFSMState_Idle>();
=======
        _FSM.SwitchStateTo<PlayerFSMState_BaseAttackAwaitCombo>();
    }

    private void DealDamage(AgentDamageable agentDamageable)
    {
        agentDamageable.ApplyDamage(69);
        Debug.Log(agentDamageable + " agentDamageable damage 69");
        //Debug.Log($"Dummy damage {_animatorController.BaseAttackComboSequenceIndex * _attackDamage}");
>>>>>>> Stashed changes
    }
}
