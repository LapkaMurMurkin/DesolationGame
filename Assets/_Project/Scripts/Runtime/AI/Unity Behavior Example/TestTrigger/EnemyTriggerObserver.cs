using UnityEngine;

public class EnemyTriggerObserver : MonoBehaviour
{
    [SerializeField] private EnemyReachedSpecificLocation _enemyReachedSpecificLocation;

    private void OnTriggerEnter(Collider other)
    {
        _enemyReachedSpecificLocation.SendEventMessage();
    }
}
