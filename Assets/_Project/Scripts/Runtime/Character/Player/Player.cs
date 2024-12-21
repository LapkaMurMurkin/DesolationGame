using UnityEngine;
using UnityEngine.UIElements.Experimental;
using R3;

public class Player : MonoBehaviour
{
    private PlayerModel _model;
    private PlayerView _view;

    private PlayerFSM _FSM;
    private PlayerInputListener _playerInputListener;
    [SerializeField]
    private PlayerDefaultInitialization _playerDefaultInitialization;

    public bool isInvulnerable;

    public void Initialize()
    {
        _model = new PlayerModel();
        _model.Initialize(_playerDefaultInitialization);
        _view = GetComponent<PlayerView>();
        _view.Initialize(_model);

        _FSM = new PlayerFSM(this, _model);
        _FSM.InitializeState(new PlayerFSMState_Idle(_FSM));
        _FSM.InitializeState(new PlayerFSMState_Movement(_FSM));
        _FSM.InitializeState(new PlayerFSMState_Dash(_FSM));
        _FSM.InitializeState(new PlayerFSMState_BaseAttack(_FSM));
        _FSM.InitializeState(new PlayerFSMState_BaseAttackAwaitCombo(_FSM));
        _FSM.InitializeState(new PlayerFSMState_SwingAttack(_FSM));
        _FSM.InitializeState(new PlayerFSMState_Death(_FSM));

        _FSM.SwitchStateTo<PlayerFSMState_Idle>();

        _playerInputListener = new PlayerInputListener(_FSM);
        _playerInputListener.Enable();
    }

    private void FixedUpdate()
    {
        _FSM.FixedUpdate();
    }

    private void Update()
    {
        _FSM.Update();
    }

    public void ApplyDamage(float damage)
    {
        _model.CurrentHealth.Value -= (int)damage;

        if (_model.CurrentHealth.Value <= 0 && _FSM.CurrentState is not PlayerFSMState_Death)
            _FSM.SwitchStateTo<PlayerFSMState_Death>();
    }

    public void ApplyVelocity(float velocity, Vector3 direction)
    {

    }

    public void UsePotion()
    {
        if (_model.CurrentPotionCharges.Value > 0)
        {
            _model.CurrentPotionCharges.Value--;
            _model.CurrentHealth.Value += (int)(_model.MaxHealth.BaseValue.Value * 0.2f);
        }
    }
}
