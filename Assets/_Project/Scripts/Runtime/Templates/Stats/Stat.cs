using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using R3;
using ObservableCollections;
using System.Linq;

//using System.Linq;

public class Stat
{
    public readonly ReactiveProperty<float> BaseValue;
    public readonly ReadOnlyReactiveProperty<float> ModifiedValue;

    private readonly ObservableList<StatModifier> _statModifiers;
    public readonly IReadOnlyObservableList<StatModifier> StatModifiers;

    public Stat(float baseValue)
    {
        BaseValue = new ReactiveProperty<float>(baseValue);
        _statModifiers = new ObservableList<StatModifier>();
        StatModifiers = _statModifiers;

        ModifiedValue = BaseValue.Select(value => CalculateModifiedValue())
            .Merge(
                StatModifiers.ObserveChanged().Select(e => CalculateModifiedValue())
        ).ToReadOnlyReactiveProperty();
    }

    private float CalculateModifiedValue()
    {
        float flatModifierSum = 0;
        float percentModifierSum = 0;

        foreach (StatModifier modifier in _statModifiers)
        {
            if (modifier.Type == StatModifierType.FLAT)
                flatModifierSum += modifier.Value;

            if (modifier.Type == StatModifierType.PERCENT)
                percentModifierSum += modifier.Value;
        }

        return BaseValue.CurrentValue + flatModifierSum + BaseValue.CurrentValue * percentModifierSum;
    }

    public void AddModifier(StatModifier modifier)
    {
        _statModifiers.Add(modifier);
    }

    public void RemoveModifier(StatModifier modifier)
    {
        _statModifiers.Remove(modifier);
    }
}
