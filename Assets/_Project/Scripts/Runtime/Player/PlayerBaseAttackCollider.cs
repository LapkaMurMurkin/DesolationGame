using System;
using UnityEngine;

public class PlayerBaseAttackCollider : MonoBehaviour
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

        //Debug.Log(collision.gameObject);
    }
}
