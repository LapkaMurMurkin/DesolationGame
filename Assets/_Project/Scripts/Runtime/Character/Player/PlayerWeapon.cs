using System;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public Action<Enemy> onEnemyCollision;

    private void OnTriggerEnter(Collider collider)
    {
        Enemy enemy = collider.gameObject.GetComponent<Enemy>();

        if (enemy is not null)
        {
            onEnemyCollision.Invoke(enemy);
/*             Destroy(enemy.gameObject);
            Debug.Log("Kill +XP"); */
        }

        Debug.Log("attack trigger enter");
    }
}
