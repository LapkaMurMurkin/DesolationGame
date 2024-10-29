using UnityEngine;

public class AgentEnemyTriggerObserver : MonoBehaviour
{
    [SerializeField] private EnemyEnterInTrigger _enemyEnterTheTrigger;
    [SerializeField] private AgentHit _agentHitEvent;
    // [SerializeField] private .ExampleBehaviourGraph _r;
    [SerializeField] private Transform _agent;
    [SerializeField] private LayerMask _targetLayer;

    private void OnTriggerEnter(Collider other)
    {
        // if(other.gameObject.layer == _targetLayer)
        _enemyEnterTheTrigger.SendEventMessage(other.transform);

        Debug.Log("SDFAS");
    }

    [ContextMenu("Hit")]
    public void Hit()
    {
        _agentHitEvent.SendEventMessage(_agent);
    }

}
