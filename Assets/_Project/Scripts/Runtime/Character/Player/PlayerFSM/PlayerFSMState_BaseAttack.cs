using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Timeline;

public class PlayerFSMState_BaseAttack : PlayerFSMState
{
    private InputAction _movement;

    private float _attackDamage;
    private float _stepRange;
    private float _stepDuration;

    public PlayerFSMState_BaseAttack(PlayerFSM FSM) : base(FSM)
    {
        _movement = ServiceLocator.Get<ActionMap>().Player.Movement;

        _animatorController.SetAtackSpeed(_FSM.Model.PlayerDefaultInitialization.BaseAttackSpeed);
        _attackDamage = _FSM.Model.PlayerDefaultInitialization.BaseAttackDamage;
        _stepRange = _FSM.Model.PlayerDefaultInitialization.BaseAttackStepRange;
        _stepDuration = _FSM.Model.PlayerDefaultInitialization.BaseAttackStepDuration;
    }

    public override void Enter()
    {
        _FSM.Player.GetComponentInChildren<PlayerWeapon>(true).onEnemyCollision += DealDamage;
        _FSM.AnimatorEvents.OnAwaitCombo += AwaitCombo;
        _FSM.AnimatorEvents.OnAnimationEnd += EndCombo;

        MakeAttack();
    }

    public override void Exit()
    {
        _FSM.Player.GetComponentInChildren<PlayerWeapon>(true).onEnemyCollision -= DealDamage;
        _FSM.AnimatorEvents.OnAwaitCombo -= AwaitCombo;
        _FSM.AnimatorEvents.OnAnimationEnd -= EndCombo;
    }

    private void MakeAttack()
    {
        _animatorController.SwitchAnimationTo(_animatorController.GetNextAttackInComboSequence(), 0f);

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
    }

    private void AwaitCombo()
    {
        //MakeAttack();
        _FSM.SwitchStateTo<PlayerFSMState_BaseAttackAwaitCombo>();
    }

    private void EndCombo()
    {
        _FSM.SwitchStateTo<PlayerFSMState_Idle>();
    }
}
