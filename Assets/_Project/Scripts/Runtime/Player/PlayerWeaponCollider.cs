using System;
using UnityEngine;

public class PlayerWeaponCollider : MonoBehaviour
{
    public Action<Dummy> onDummyCollision;
    public Action<AgentDamageable> onAgentDamageableCollision;

    private void OnCollisionEnter(Collision collision)
    {
        Dummy dummy = collision.gameObject.GetComponent<Dummy>();
        AgentDamageable agentDamageable = collision.gameObject.GetComponent<AgentDamageable>();

        if (dummy is not null)
        {
            Destroy(dummy.gameObject);
            Debug.Log("Kill +XP");
        }

        if (agentDamageable is not null)
            //onDummyCollision.Invoke(dummy);
            onAgentDamageableCollision.Invoke(agentDamageable);

        Debug.Log(collision.gameObject);
    }

    private void OnTriggerEnter(Collider collider)
    {
        AgentDamageable agentDamageable = collider.gameObject.GetComponent<AgentDamageable>();

        if (agentDamageable is not null)
            //onDummyCollision.Invoke(dummy);
            onAgentDamageableCollision.Invoke(agentDamageable);

        //Debug.Log(other.gameObject + " trigger");
    }
}
