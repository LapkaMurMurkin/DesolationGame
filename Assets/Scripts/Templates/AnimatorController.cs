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
