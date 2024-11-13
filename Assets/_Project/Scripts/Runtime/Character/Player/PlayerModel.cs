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
    public ReadOnlyDictionary<StatID, Stat> Stats;
    public ReadOnlyArray<int> LevelsXP;

    public PlayerDefaultInitialization PlayerDefaultInitialization;

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

        int[] levelsXP = {
            100,
            200,
            300,
            999999999
        };

        LevelsXP = new ReadOnlyArray<int>(levelsXP);

        experience.BaseValue.Subscribe(value => level.BaseValue.Value = CheckLevelUp((int)value, levelsXP));
    }

    public void Initialize(PlayerDefaultInitialization initStats)
    {
        PlayerDefaultInitialization = initStats;

        Stats[StatID.LEVEL].BaseValue.Value = initStats.Level;
        Stats[StatID.EXPERIENCE].BaseValue.Value = initStats.Experience;
        Stats[StatID.MAX_HEALTH].BaseValue.Value = initStats.Health;
        Stats[StatID.CURRENT_HEALTH].BaseValue.Value = initStats.Health;
        Stats[StatID.MAX_MANA].BaseValue.Value = initStats.Mana;
        Stats[StatID.CURRENT_MANA].BaseValue.Value = initStats.Mana;
        Stats[StatID.BASE_DAMAGE].BaseValue.Value = initStats.BaseAttackDamage;
        Stats[StatID.ATTACK_SPEED].BaseValue.Value = initStats.BaseAttackSpeed;
        Stats[StatID.MOVEMENT_SPEED].BaseValue.Value = initStats.MovementSpeed;
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
