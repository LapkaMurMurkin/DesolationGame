using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStatsInitialization", menuName = "ScriptableObjects/PlayerStatsInitialization", order = 1)]
public class PlayerStatsInitialization : ScriptableObject
{
    public int Level;
    public int Experience;
    public int Health;
    public int Mana;
    public int BaseDamage;
    public float AttackSpeed;
    public float MovementSpeed;
}