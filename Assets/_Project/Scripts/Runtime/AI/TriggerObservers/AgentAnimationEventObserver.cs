using UnityEngine;

public class AgentAnimationEventObserver : MonoBehaviour
{
    [SerializeField] private EnemyPreparedToAttackEvent _enemyPreparedToAttackEvent;
    [SerializeField] private EnemyPerformAttackEvent _enemyPerformAttackEvent;

    public void PreparedToAttack()
    {
        _enemyPreparedToAttackEvent.SendEventMessage();
    }

    public void PerformAttack()
    {
        _enemyPerformAttackEvent.SendEventMessage();
    }
}
