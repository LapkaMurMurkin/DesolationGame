using System.Collections.Generic;
using System.Collections.ObjectModel;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerModel
{
    public ReadOnlyDictionary<StatID, Stat> Stats;

    public PlayerModel()
    {
        Dictionary<StatID, Stat> stats = new Dictionary<StatID, Stat>{

            {StatID.LEVEL, new Stat(1)},
            {StatID.EXPERIENCE, new Stat(0)},
            {StatID.MAX_HEALTH, new Stat(100)},
            {StatID.CURRENT_HEALTH, new Stat(100)},
            {StatID.MAX_MANA, new Stat(20)},
            {StatID.CURRENT_MANA, new Stat(20)},
            {StatID.BASE_DAMAGE, new Stat(20)},
            {StatID.ATTACK_SPEED, new Stat(20)},
            {StatID.MOVEMENT_SPEED, new Stat(20)}
        };

        Stats = new ReadOnlyDictionary<StatID, Stat>(stats);
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
    }
}
