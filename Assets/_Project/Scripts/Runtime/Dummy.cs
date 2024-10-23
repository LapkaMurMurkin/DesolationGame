using System;
using JetBrains.Annotations;
using UnityEngine;

public class Dummy : MonoBehaviour
{
    private Stat CurrentHealth;
    private Stat MaxHealth;

    private void Awake()
    {
        MaxHealth = new Stat(20);
        CurrentHealth = new Stat(MaxHealth.BaseValue.Value);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerWeaponCollider>() is PlayerWeaponCollider)
            Debug.Log("Dummy Hit!");
    }
}
