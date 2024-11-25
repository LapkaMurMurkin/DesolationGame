using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStatsInitialization", menuName = "ScriptableObjects/PlayerStatsInitialization", order = 1)]
public class PlayerDefaultInitialization : ScriptableObject
{
    [Header("Stats")]
    public int Level;
    public int Experience;
    public int Health;
    public int Mana;

    [Header("Movement")]
    public float MovementSpeed;
    public float MovementAccelerationDuration;
    public float MovementDecelerationDuration;

    [Header("Dash")]
    public float DashRange;
    public float DashDuration;

    [Header("BaseAttack")]
    public int BaseAttackDamage;
    public float BaseAttackSpeed;
    public float BaseAttackStepRange;
    public float BaseAttackStepDuration;
}