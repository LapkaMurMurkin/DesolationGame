using System;
using UnityEngine;

public class PlayerWeaponCollider : MonoBehaviour
{
    public Action<Dummy> onDummyCollision;

    private void OnCollisionEnter(Collision collision)
    {
        Dummy dummy = collision.gameObject.GetComponent<Dummy>();
        if (dummy is not null)
            onDummyCollision.Invoke(dummy);
    }
}
