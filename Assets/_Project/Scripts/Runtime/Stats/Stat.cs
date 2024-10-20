using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using R3;
using ObservableCollections;
using System.Linq;

//using System.Linq;

public class Stat
{
    public readonly ReactiveProperty<int> BaseValue;
    public readonly ReadOnlyReactiveProperty<int> ModifiedValue;

    private readonly ObservableList<StatModifier> _statModifiers;
    public readonly IReadOnlyObservableList<StatModifier> StatModifiers;

    public Stat(int baseValue)
    {
        BaseValue = new ReactiveProperty<int>(baseValue);
        _statModifiers = new ObservableList<StatModifier>();
        StatModifiers = _statModifiers;

        ModifiedValue = BaseValue.Select(value => CalculateModifiedValue())
            .Merge(
                StatModifiers.ObserveChanged().Select(e => CalculateModifiedValue())
        ).ToReadOnlyReactiveProperty();

/*         BaseValue.Subscribe(value => Debug.Log("Base" + BaseValue.CurrentValue));
        ModifiedValue.Subscribe(value => Debug.Log("Mode" + ModifiedValue.CurrentValue)); */
    }

    private int CalculateModifiedValue()
    {
        int flatModifierSum = 0;
        int percentModifierSum = 0;

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
