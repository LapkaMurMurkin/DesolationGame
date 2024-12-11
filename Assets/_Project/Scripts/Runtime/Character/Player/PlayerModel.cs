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
<<<<<<< Updated upstream
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
=======
    public ReadOnlyDictionary<StatID, Stat> Stats;
    public ReadOnlyArray<int> LevelsXP;

    public PlayerModel()
    {
        Stat level = new Stat(1);
        Stat experience = new Stat(0);
        Stat maxHealth = new Stat(100);
        Stat currentHealth = new Stat(100);
        Stat maxMana = new Stat(20);
        Stat currentMana = new Stat(20);
        Stat baseDamage = new Stat(10);
        Stat attackSpeed = new Stat(1);
        Stat movementSpeed = new Stat(5);

        Dictionary<StatID, Stat> stats = new Dictionary<StatID, Stat>{

            {StatID.LEVEL, level},
            {StatID.EXPERIENCE, experience},
            {StatID.MAX_HEALTH, maxHealth},
            {StatID.CURRENT_HEALTH, currentHealth},
            {StatID.MAX_MANA, maxMana},
            {StatID.CURRENT_MANA, currentMana},
            {StatID.BASE_DAMAGE, baseDamage},
            {StatID.ATTACK_SPEED, attackSpeed},
            {StatID.MOVEMENT_SPEED, movementSpeed}
        };

        Stats = new ReadOnlyDictionary<StatID, Stat>(stats);
>>>>>>> Stashed changes

        int[] levelsXP = {
            100,
            200,
<<<<<<< Updated upstream
            300,
            999999999
=======
            300
>>>>>>> Stashed changes
        };

        LevelsXP = new ReadOnlyArray<int>(levelsXP);

<<<<<<< Updated upstream
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
=======
        experience.BaseValue.Subscribe(value => level.BaseValue.Value = CheckLevelUp((int)value, levelsXP));
        currentHealth.BaseValue.Subscribe(value =>
        {
            if (value <= 0)
            {
                Debug.Log("Player Death");
            }
        });
    }

    public void Initialize(PlayerStatsInitialization initStats)
    {
        Stats[StatID.LEVEL].BaseValue.Value = initStats.Level;
        Stats[StatID.EXPERIENCE].BaseValue.Value = initStats.Experience;
        Stats[StatID.MAX_HEALTH].BaseValue.Value = initStats.Health;
        Stats[StatID.CURRENT_HEALTH].BaseValue.Value = initStats.Health;
        Stats[StatID.MAX_MANA].BaseValue.Value = initStats.Mana;
        Stats[StatID.CURRENT_MANA].BaseValue.Value = initStats.Mana;
        Stats[StatID.BASE_DAMAGE].BaseValue.Value = initStats.BaseDamage;
        Stats[StatID.ATTACK_SPEED].BaseValue.Value = initStats.AttackSpeed;
        Stats[StatID.MOVEMENT_SPEED].BaseValue.Value = initStats.MovementSpeed;
>>>>>>> Stashed changes
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
