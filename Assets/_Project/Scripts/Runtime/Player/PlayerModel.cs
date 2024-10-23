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
            {StatID.CURRENT_MANA, new Stat(20)}
        };

        Stats = new ReadOnlyDictionary<StatID, Stat>(stats);
    }

    public void Initialize()
    {

    }
}
