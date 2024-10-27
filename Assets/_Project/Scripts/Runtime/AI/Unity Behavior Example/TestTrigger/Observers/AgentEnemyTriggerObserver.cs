using UnityEngine;

public class AgentEnemyTriggerObserver : MonoBehaviour
{
    [SerializeField] private EnemyEnterInTrigger _enemyEnterTheTrigger;
    [SerializeField] private LayerMask _targetLayer;

    private void OnTriggerEnter(Collider other)
    {
        // if(other.gameObject.layer == _targetLayer)
        _enemyEnterTheTrigger.SendEventMessage(other.transform);

        Debug.Log("SDFAS");
    }

}
