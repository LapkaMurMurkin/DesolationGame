using UnityEngine;

public class AgentEnemyTriggerObserver : MonoBehaviour
{
    [SerializeField] private EnemyEnterInTrigger _enemyEnterTheTrigger;

    private void OnTriggerEnter(Collider other)
    {
        _enemyEnterTheTrigger.SendEventMessage(other.transform);
    }
}
