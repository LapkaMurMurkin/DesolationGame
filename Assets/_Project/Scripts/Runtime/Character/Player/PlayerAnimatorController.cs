using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using TMPro;
using UnityEngine;

public class PlayerAnimatorController : AnimatorController
{
    public const string IDLE_ANIM_NAME = "Idle";
    public const string RUN_ANIM_NAME = "Run";
<<<<<<< Updated upstream
    public const string DASH_ANIM_NAME = "Dash";
=======
>>>>>>> Stashed changes
    public const string BASE_ATTACK_1_ANIM_NAME = "BaseAttack_1";
    public const string BASE_ATTACK_AWAIT_COMBO_1_ANIM_NAME = "BaseAttackAwaitCombo_1";
    public const string BASE_ATTACK_END_1_ANIM_NAME = "BaseAttackEnd_1";
    public const string BASE_ATTACK_2_ANIM_NAME = "BaseAttack_2";
    public const string BASE_ATTACK_AWAIT_COMBO_2_ANIM_NAME = "BaseAttackAwaitCombo_2";
    public const string BASE_ATTACK_END_2_ANIM_NAME = "BaseAttackEnd_2";
    public const string BASE_ATTACK_3_ANIM_NAME = "BaseAttack_3";
    public const string BASE_ATTACK_END_3_ANIM_NAME = "BaseAttackEnd_3";
<<<<<<< Updated upstream
    public const string DEATH_ANIM_NAME = "Death";
=======
>>>>>>> Stashed changes

    public const string ATTACK_SPEED_VAR = "AttackSpeed";

    public IReadOnlyList<string> BaseAttackComboSequence;
    public int BaseAttackComboSequenceIndex;

    public PlayerAnimatorController(Animator animator) : base(animator)
    {
        BaseAttackComboSequence = new List<string>{
            {BASE_ATTACK_1_ANIM_NAME},
            //{BASE_ATTACK_AWAIT_COMBO_1_ANIM_NAME},
            //{BASE_ATTACK_END_1_ANIM_NAME},
            {BASE_ATTACK_2_ANIM_NAME},
            //{BASE_ATTACK_AWAIT_COMBO_2_ANIM_NAME},
            //{BASE_ATTACK_END_2_ANIM_NAME},
            {BASE_ATTACK_3_ANIM_NAME},
            //{BASE_ATTACK_END_3_ANIM_NAME},
        };

        BaseAttackComboSequenceIndex = 0;
    }

    public string GetNextAttackInComboSequence()
    {
        if (BaseAttackComboSequenceIndex > BaseAttackComboSequence.Count - 1)
            BaseAttackComboSequenceIndex = 0;

        return BaseAttackComboSequence[BaseAttackComboSequenceIndex++];
    }
<<<<<<< Updated upstream

    public void SetAtackSpeed(float value)
    {
        _animator.SetFloat(ATTACK_SPEED_VAR, value);
    }
=======
>>>>>>> Stashed changes
}
