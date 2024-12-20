using System;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public Action<Player> OnPlayerCollision;

    private void OnTriggerEnter(Collider collider)
    {
        Player player = collider.gameObject.GetComponent<Player>();

        if (player is not null)
        {
            OnPlayerCollision?.Invoke(player);
        }

        UnityEngine.Debug.Log(collider.gameObject.name);

    }
}
