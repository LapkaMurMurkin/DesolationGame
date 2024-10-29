using System.ComponentModel;
using UnityEngine;

public class PlayerDamageableComponent : MonoBehaviour
{
    [SerializeField] private float _health = 100f;

    public void ApplyDamage(float damage)
    {
        _health -= damage;
        Debug.Log($"Damage taken, current health: {_health}");
    }
}
