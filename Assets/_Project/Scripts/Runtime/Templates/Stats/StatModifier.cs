using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatModifier
{
    public readonly float Value;
    public readonly StatModifierType Type;

    public StatModifier(float value, StatModifierType type)
    {
        Value = value;
        Type = type;
    }
}
