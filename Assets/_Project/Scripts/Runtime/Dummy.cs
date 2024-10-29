using System;
using JetBrains.Annotations;
using UnityEngine;

public class Dummy : MonoBehaviour
{
    private Stat CurrentHealth;
    private Stat MaxHealth;

    private Material _material;
    private float _timer;

    private void Awake()
    {
        MaxHealth = new Stat(20);
        CurrentHealth = new Stat(MaxHealth.BaseValue.Value);

        _material = GetComponent<Renderer>().material;
        _material.color = Color.green;
        _timer = 0.25f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        PlayerBaseAttackCollider collider = collision.gameObject.GetComponent<PlayerBaseAttackCollider>();

        if (collider is not null)
        {
            _timer = 0.25f;
            _material.color = Color.red;
            Debug.Log("Dummy Hit!");
        }
    }

    private void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0)
            _material.color = Color.green;

    }
}
