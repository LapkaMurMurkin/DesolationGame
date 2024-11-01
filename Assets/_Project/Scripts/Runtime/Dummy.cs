using System;
using JetBrains.Annotations;
using UnityEngine;

public class Dummy : MonoBehaviour
{
    private Stat CurrentHealth;
    private Stat MaxHealth;

    private Material _material;
    private float _timer;

    private float _lastHit;
    private Player _player;

    private void Awake()
    {
        MaxHealth = new Stat(20);
        CurrentHealth = new Stat(MaxHealth.BaseValue.Value);

        _material = GetComponent<Renderer>().material;
        _material.color = Color.green;
        /*         _timer = 0.25f;
                _lastHit = 0; */

        _player = ServiceLocator.Get<Player>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player is not null && !player.isInvulnerable)
        {
            player.ApplyDamage(10);
            Destroy(gameObject);
            Debug.Log("Dummy collision with player");
        }
        /*         PlayerBaseAttackCollider collider = collision.gameObject.GetComponent<PlayerBaseAttackCollider>();

                if (collider is not null)
                {
                    _timer = 0.25f;
                    _material.color = Color.red;
                    Debug.Log("Dummy Hit!");

                    Debug.Log(_lastHit);
                    _lastHit = 0;
                } */
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, 1 * Time.deltaTime);

        /*         _lastHit += Time.deltaTime;
                _timer -= Time.deltaTime;
                if (_timer <= 0)
                    _material.color = Color.green;
         */
    }
}
