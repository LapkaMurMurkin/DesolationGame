using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices.WindowsRuntime;
using R3;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Utilities;

public class PlayerModel
{
    public ReactiveProperty<int> Level;
    public ReactiveProperty<int> Experience;
    public ReadOnlyArray<int> LevelsXP;

    public Stat MaxHealth;
    public ReactiveProperty<int> CurrentHealth;

    public Stat MaxMana;
    public ReactiveProperty<int> CurrentMana;

    public ReactiveProperty<int> MaxPotionCharges;
    public ReactiveProperty<int> CurrentPotionCharges;

    public Stat BaseDamage;
    public Stat AttackSpeed;
    public Stat MovementSpeed;

    public PlayerDefaultInitialization PlayerDefaultInitialization;

    public PlayerModel()
    {
        Level = new ReactiveProperty<int>(1);
        Experience = new ReactiveProperty<int>(0);

        int[] levelsXP = {
            100,
            200,
            300,
            999999999
        };

        LevelsXP = new ReadOnlyArray<int>(levelsXP);

        Experience.Subscribe(value => Level.Value = CheckLevelUp((int)value, levelsXP));

        MaxHealth = new Stat(100);
        CurrentHealth = new ReactiveProperty<int>((int)MaxHealth.BaseValue.Value);
        CurrentHealth.Subscribe(value =>
        {
            if (value < 0)
                CurrentHealth.Value = 0;
            if (value > MaxHealth.ModifiedValue.CurrentValue)
                CurrentHealth.Value = (int)MaxHealth.ModifiedValue.CurrentValue;
        });

        MaxMana = new Stat(20);
        CurrentMana = new ReactiveProperty<int>((int)MaxMana.BaseValue.Value);
        CurrentMana.Subscribe(value =>
        {
            if (value < 0)
                CurrentMana.Value = 0;
            if (value > MaxHealth.ModifiedValue.CurrentValue)
                CurrentMana.Value = (int)MaxMana.ModifiedValue.CurrentValue;
        });

        MaxPotionCharges = new ReactiveProperty<int>(3);
        CurrentPotionCharges = new ReactiveProperty<int>(MaxPotionCharges.Value);

        BaseDamage = new Stat(10);
        AttackSpeed = new Stat(1);
        MovementSpeed = new Stat(5);
    }

    public void Initialize(PlayerDefaultInitialization initStats)
    {
        PlayerDefaultInitialization = initStats;

        Level.Value = initStats.Level;
        Experience.Value = initStats.Experience;

        MaxHealth.BaseValue.Value = initStats.Health;
        CurrentHealth.Value = initStats.Health;

        MaxMana.BaseValue.Value = initStats.Mana;
        CurrentMana.Value = initStats.Mana;

        BaseDamage.BaseValue.Value = initStats.BaseAttackDamage;
        AttackSpeed.BaseValue.Value = (int)(initStats.BaseAttackSpeed * 100);
        MovementSpeed.BaseValue.Value = (int)(initStats.MovementSpeed * 100);
    }

    public int CheckLevelUp(int xp, int[] arr)
    {
        for (int i = 0; i <= arr.Length; i++)
        {
            if (xp < arr[i])
                return i + 1;
        }

        return 12345;
    }
}
