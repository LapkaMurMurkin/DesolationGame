using R3;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class PlayerView : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _level;
    [SerializeField]
    private TextMeshProUGUI _experience;
    [SerializeField]
    private TextMeshProUGUI _health;
    [SerializeField]
    private TextMeshProUGUI _mana;
    [SerializeField]
    private TextMeshProUGUI _speed;
    [SerializeField]
    private TextMeshProUGUI _damage;
    [SerializeField]
    private TextMeshProUGUI _attackSpeed;

    public void Initialize(PlayerModel playerModel)
    {
        ReadOnlyReactiveProperty<float> level = playerModel.Stats[StatID.LEVEL].ModifiedValue;
        ReadOnlyReactiveProperty<float> experience = playerModel.Stats[StatID.EXPERIENCE].ModifiedValue;
        ReadOnlyReactiveProperty<float> maxHealth = playerModel.Stats[StatID.MAX_HEALTH].ModifiedValue;
        ReadOnlyReactiveProperty<float> currentHealth = playerModel.Stats[StatID.CURRENT_HEALTH].ModifiedValue;
        ReadOnlyReactiveProperty<float> maxMana = playerModel.Stats[StatID.MAX_MANA].ModifiedValue;
        ReadOnlyReactiveProperty<float> currentMana = playerModel.Stats[StatID.CURRENT_MANA].ModifiedValue;
        ReadOnlyReactiveProperty<float> baseDamage = playerModel.Stats[StatID.BASE_DAMAGE].ModifiedValue;
        ReadOnlyReactiveProperty<float> attackSpeed = playerModel.Stats[StatID.ATTACK_SPEED].ModifiedValue;
        ReadOnlyReactiveProperty<float> movementSpeed = playerModel.Stats[StatID.MOVEMENT_SPEED].ModifiedValue;

        level.Subscribe(value => _level.text = $"Level: {value}").AddTo(this);
        experience.Subscribe(value => _experience.text = $"XP: {value}").AddTo(this);
        maxHealth.Merge(currentHealth).Subscribe(value => _health.text = $"Health: {currentHealth.CurrentValue} \\ {maxHealth.CurrentValue}").AddTo(this);
        maxMana.Merge(currentMana).Subscribe(value => _mana.text = $"Mana: {currentMana.CurrentValue} \\ {maxMana.CurrentValue}").AddTo(this);
        movementSpeed.Subscribe(value => _speed.text = $"Speed: {value}").AddTo(this);
        baseDamage.Subscribe(value => _damage.text = $"Damage: {value}").AddTo(this);
        attackSpeed.Subscribe(value => _attackSpeed.text = $"AttackSpeed: {value}").AddTo(this);
    }
}
