using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStatsInitialization", menuName = "ScriptableObjects/PlayerStatsInitialization", order = 1)]
public class PlayerStatsInitialization : ScriptableObject
{
    public float Health;
    public float Mana;
    public float AttackDamage;
    public float AttackSpeed;
    public float MovementSpeed;
}