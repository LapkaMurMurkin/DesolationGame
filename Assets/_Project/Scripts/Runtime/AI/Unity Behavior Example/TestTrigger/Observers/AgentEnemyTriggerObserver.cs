using UnityEngine;

public class AgentEnemyTriggerObserver : MonoBehaviour
{
    [SerializeField] private EnemyEnterInTrigger _enemyEnterTheTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.GetComponent<Player>() != null)
            _enemyEnterTheTrigger.SendEventMessage(other.transform);
    }
}
