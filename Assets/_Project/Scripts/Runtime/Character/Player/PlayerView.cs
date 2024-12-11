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
    private TextMeshProUGUI _potion;
    [SerializeField]
    private TextMeshProUGUI _speed;
    [SerializeField]
    private TextMeshProUGUI _damage;
    [SerializeField]
    private TextMeshProUGUI _attackSpeed;


    public void Initialize(PlayerModel playerModel)
    {
        ReadOnlyReactiveProperty<int> level = playerModel.Level;
        ReadOnlyReactiveProperty<int> experience = playerModel.Experience;

        ReadOnlyReactiveProperty<float> maxHealth = playerModel.MaxHealth.ModifiedValue;
        ReadOnlyReactiveProperty<int> currentHealth = playerModel.CurrentHealth;

        ReadOnlyReactiveProperty<float> maxMana = playerModel.MaxMana.ModifiedValue;
        ReadOnlyReactiveProperty<int> currentMana = playerModel.CurrentMana;

        ReadOnlyReactiveProperty<int> maxPotionCharges = playerModel.MaxPotionCharges;
        ReadOnlyReactiveProperty<int> currentPotionCharges = playerModel.CurrentPotionCharges;

        ReadOnlyReactiveProperty<float> baseDamage = playerModel.BaseDamage.ModifiedValue;
        ReadOnlyReactiveProperty<float> attackSpeed = playerModel.AttackSpeed.ModifiedValue;
        ReadOnlyReactiveProperty<float> movementSpeed = playerModel.MovementSpeed.ModifiedValue;

        level.Subscribe(value => _level.text = $"Level: {value}").AddTo(this);
        experience.Subscribe(value => _experience.text = $"XP: {value}").AddTo(this);

        maxHealth.Subscribe(value => _health.text = $"Health: {currentHealth.CurrentValue} \\ {maxHealth.CurrentValue}").AddTo(this);
        currentHealth.Subscribe(value => _health.text = $"Health: {currentHealth.CurrentValue} \\ {maxHealth.CurrentValue}").AddTo(this);

        maxMana.Subscribe(value => _mana.text = $"Mana: {currentMana.CurrentValue} \\ {maxMana.CurrentValue}").AddTo(this);
        currentMana.Subscribe(value => _mana.text = $"Mana: {currentMana.CurrentValue} \\ {maxMana.CurrentValue}").AddTo(this);

        maxPotionCharges.Subscribe(value => _potion.text = $"Potion: {currentPotionCharges.CurrentValue} \\ {maxPotionCharges.CurrentValue}").AddTo(this);
        currentPotionCharges.Subscribe(value => _potion.text = $"Potion: {currentPotionCharges.CurrentValue} \\ {maxPotionCharges.CurrentValue}").AddTo(this);

        movementSpeed.Subscribe(value => _speed.text = $"Speed: {value}").AddTo(this);
        baseDamage.Subscribe(value => _damage.text = $"Damage: {value}").AddTo(this);
        attackSpeed.Subscribe(value => _attackSpeed.text = $"AttackSpeed: {value}").AddTo(this);
    }
}
