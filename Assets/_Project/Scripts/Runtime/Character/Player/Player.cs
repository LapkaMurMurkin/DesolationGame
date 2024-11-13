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
        _model.Stats[StatID.CURRENT_HEALTH].BaseValue.Value -= damage;
        Debug.Log($"Player - damage: {damage}");

        if (_model.Stats[StatID.CURRENT_HEALTH].BaseValue.Value <= 0)
            _FSM.SwitchStateTo<PlayerFSMState_Death>();
    }
}
