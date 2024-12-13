using System;
using UnityEngine;

public class PlayerBaseAttackCollider : MonoBehaviour
{
    public Action<Dummy> onDummyCollision;

    private void OnCollisionEnter(Collision collision)
    {
        Dummy dummy = collision.gameObject.GetComponent<Dummy>();

        if (dummy is not null)
        {
            Destroy(dummy.gameObject);
            Debug.Log("Kill +XP");
        }
    }
}
