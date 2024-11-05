using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatModifier
{
    public readonly int Value;
    public readonly StatModifierType Type;

    public StatModifier(int value, StatModifierType type)
    {
        Value = value;
        Type = type;
    }
}
