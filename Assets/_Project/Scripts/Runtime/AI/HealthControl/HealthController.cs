using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField] private AgentHit _agentDamagedEvent;
    [SerializeField] private AgentDeath _agentDeathEvent;
    [SerializeField] private GameObject _agent;
    [SerializeField, Min(0)] private int _startHealth = 100;
    private int _currentHealth;
    private bool _isDead;

    private void Start()
    {
        _currentHealth = _startHealth;        
        _isDead = false;
    }

    public void CalculateDamage(int inputDamage)
    {
        if(_isDead)
            return;
        _currentHealth -= inputDamage;

        if(_currentHealth > 0)
            _agentDamagedEvent.SendEventMessage(_agent.transform);
        else
        {
            _agentDeathEvent.SendEventMessage(_agent);
            _isDead = true;
        }
    }
}
