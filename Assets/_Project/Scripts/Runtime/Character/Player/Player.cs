using UnityEngine;
using UnityEngine.UIElements.Experimental;
using R3;

<<<<<<< Updated upstream
public class Player : MonoBehaviour
=======
public class Player : Character
>>>>>>> Stashed changes
{
    private PlayerModel _model;
    private PlayerView _view;

    private PlayerFSM _FSM;
    private PlayerInputListener _playerInputListener;
    [SerializeField]
<<<<<<< Updated upstream
    private PlayerDefaultInitialization _playerDefaultInitialization;
=======
    public PlayerStatsInitialization _playerStatsInitialization;
    [SerializeField]
    private AgentDeath _agetDeathTest;
>>>>>>> Stashed changes

    public bool isInvulnerable;

    public void Initialize()
    {
        _model = new PlayerModel();
<<<<<<< Updated upstream
        _model.Initialize(_playerDefaultInitialization);
=======
        _model.Initialize(_playerStatsInitialization);
>>>>>>> Stashed changes
        _view = GetComponent<PlayerView>();
        _view.Initialize(_model);

        _FSM = new PlayerFSM(this, _model);
        _FSM.InitializeState(new PlayerFSMState_Idle(_FSM));
        _FSM.InitializeState(new PlayerFSMState_Movement(_FSM));
        _FSM.InitializeState(new PlayerFSMState_Dash(_FSM));
        _FSM.InitializeState(new PlayerFSMState_BaseAttack(_FSM));
        _FSM.InitializeState(new PlayerFSMState_BaseAttackAwaitCombo(_FSM));
        _FSM.InitializeState(new PlayerFSMState_SwingAttack(_FSM));
<<<<<<< Updated upstream
        _FSM.InitializeState(new PlayerFSMState_Death(_FSM));

=======
>>>>>>> Stashed changes
        _FSM.SwitchStateTo<PlayerFSMState_Idle>();

        _playerInputListener = new PlayerInputListener(_FSM);
        _playerInputListener.Enable();
<<<<<<< Updated upstream
    }

    private void FixedUpdate()
    {
        _FSM.FixedUpdate();
=======

        _agetDeathTest.Event += (gameObject) =>
        {
            Debug.Log("death");
            _model.Stats[StatID.EXPERIENCE].BaseValue.Value += 100;
        };
>>>>>>> Stashed changes
    }

    private void Update()
    {
        _FSM.Update();
    }

<<<<<<< Updated upstream
    public void ApplyDamage(float damage)
    {
        _model.CurrentHealth.Value -= (int)damage;
        Debug.Log($"Player - damage: {damage}");

        if (_model.CurrentHealth.Value <= 0 && _FSM.CurrentState is not PlayerFSMState_Death)
            _FSM.SwitchStateTo<PlayerFSMState_Death>();
    }

    public void UsePotion()
    {
        if (_model.CurrentPotionCharges.Value > 0)
        {
            _model.CurrentPotionCharges.Value--;
            _model.CurrentHealth.Value += (int)(_model.MaxHealth.BaseValue.Value * 0.2f);
        }
=======
    public void ApplyDamage(int damage)
    {
        _model.Stats[StatID.CURRENT_HEALTH].BaseValue.Value -= damage;
>>>>>>> Stashed changes
    }
}
