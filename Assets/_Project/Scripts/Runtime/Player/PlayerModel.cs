using System.Collections.Generic;
using System.Collections.ObjectModel;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerModel
{
    public ReadOnlyDictionary<StatID, Stat> Stats;

    public PlayerModel()
    {
        Stat level = new Stat(1);
        Stat experience = new Stat(0);
        Stat maxHealth = new Stat(100);
        Stat currentHealth = new Stat(100);
        Stat maxMana = new Stat(20);
        Stat currentMana = new Stat(20);

        Dictionary<StatID, Stat> stats = new Dictionary<StatID, Stat>();
        stats.Add(StatID.LEVEL, level);
        stats.Add(StatID.EXPERIENCE, experience);
        stats.Add(StatID.MAX_HEALTH, maxHealth);
        stats.Add(StatID.CURRENT_HEALTH, currentHealth);
        stats.Add(StatID.MAX_MANA, maxMana);
        stats.Add(StatID.CURRENT_MANA, currentMana);

        Stats = new ReadOnlyDictionary<StatID, Stat>(stats);
    }

    public void Initialize()
    {

    }
}
