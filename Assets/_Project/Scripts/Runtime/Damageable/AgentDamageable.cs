using UnityEngine;

public class AgentDamageable : MonoBehaviour, IDamageable
{
    [SerializeField] private HealthController _healthController;
    [SerializeField] private int _testDamage;

    [ContextMenu("Test Hit")]
    public void Hit()
    {
        ApplyDamage(_testDamage);
    }

    public void ApplyDamage(int damage)
    {
        _healthController.CalculateDamage(damage);
    }
}
