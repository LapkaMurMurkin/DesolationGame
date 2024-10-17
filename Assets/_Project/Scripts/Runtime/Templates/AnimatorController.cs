using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;

public class AnimatorController
{
    private Animator _animator;
    private string _currentAnimation;

    public const string IDLE_ANIM_NAME = "Idle";
    public const string RUN_ANIM_NAME = "Run";
    public const string ATTACK_ANIM_NAME = "Attack";
    public static string ATTACK_SPEED_VAR = "AttackSpeed";

    public AnimatorController(Animator animator)
    {
        _animator = animator;
    }
    public void SwitchAnimationTo(string animationName, float crossFade = 0.2f)
    {
        if (_currentAnimation != animationName)
        {
            _animator.CrossFade(animationName, crossFade);
            _currentAnimation = animationName;
        }
    }
}
