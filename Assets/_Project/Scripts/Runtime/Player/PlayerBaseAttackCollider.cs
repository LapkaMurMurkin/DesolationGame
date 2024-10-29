using System;
using UnityEngine;

public class PlayerBaseAttackCollider : MonoBehaviour
{
    public Action<Dummy> onDummyCollision;

    private void OnCollisionEnter(Collision collision)
    {
        Dummy dummy = collision.gameObject.GetComponent<Dummy>();
        if (dummy is not null)
            onDummyCollision.Invoke(dummy);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.TryGetComponent(out IDamageable damageable))
        {
            damageable.ApplyDamage(15);
        }
    }
}
