using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorEvents : AnimatorEvents
{
    public Action OnAwaitCombo;
    private void AwaitComboEvent() => OnAwaitCombo?.Invoke();
}
