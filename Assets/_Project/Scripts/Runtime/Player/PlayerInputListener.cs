using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputListener
{
    private PlayerFSM _FSM;
    private ActionMap _actionMap;
    private InputAction _movement;
    private InputAction _dash;
    private InputAction _attack;
    private InputAction _skill_1;

    private Dictionary<Type, HashSet<Type>> _transitionToFromAccess;

    public PlayerInputListener(PlayerFSM FSM)
    {
        _FSM = FSM;
        _actionMap = ServiceLocator.Get<ActionMap>();
        _movement = _actionMap.Player.Movement;
        _dash = _actionMap.Player.Dash;
        _attack = _actionMap.Player.Attack;
        _skill_1 = _actionMap.Player.Skill_1;

        _transitionToFromAccess = new Dictionary<Type, HashSet<Type>>();
        _transitionToFromAccess.Add(typeof(PlayerFSMState_BaseAttack), new HashSet<Type>());
        _transitionToFromAccess[typeof(PlayerFSMState_BaseAttack)].Add(typeof(PlayerFSMState_Idle));
        _transitionToFromAccess[typeof(PlayerFSMState_BaseAttack)].Add(typeof(PlayerFSMState_Movement));
        _transitionToFromAccess[typeof(PlayerFSMState_BaseAttack)].Add(typeof(PlayerFSMState_BaseAttackAwaitCombo));
    }

    public void Enable()
    {
        _movement.performed += Move;
        _dash.performed += Dash;
        _attack.performed += Attack;
        _skill_1.performed += Skill_1;
    }

    public void Disable()
    {
        _movement.performed -= Move;
        _dash.performed -= Dash;
        _attack.performed -= Attack;
        _skill_1.performed -= Skill_1;
    }

    private void Move(InputAction.CallbackContext context)
    {
        if (_FSM.CurrentState is not PlayerFSMState_Movement)
            _FSM.SwitchStateTo<PlayerFSMState_Movement>();
    }

    private void Dash(InputAction.CallbackContext context)
    {
        if (_FSM.CurrentState is not PlayerFSMState_Dash)
            _FSM.SwitchStateTo<PlayerFSMState_Dash>();
    }

    private void Attack(InputAction.CallbackContext context)
    {
        if (_FSM.CurrentState is not PlayerFSMState_BaseAttackAwaitCombo)
            _FSM.AnimatorController.BaseAttackComboSequenceIndex = 0;

        if (_transitionToFromAccess[typeof(PlayerFSMState_BaseAttack)].Contains(_FSM.CurrentState.GetType()))
            _FSM.SwitchStateTo<PlayerFSMState_BaseAttack>();
    }

    private void Skill_1(InputAction.CallbackContext context)
    {
        if (_FSM.CurrentState is not PlayerFSMState_SwingAttack)
            _FSM.SwitchStateTo<PlayerFSMState_SwingAttack>();
    }
}
