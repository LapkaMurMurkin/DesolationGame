using UnityEngine;
using UnityEngine.UIElements.Experimental;
using R3;

public class Player : MonoBehaviour
{
    private PlayerModel _model;

    private PlayerFSM _FSM;
    private PlayerInputListener _playerInputListener;
    [SerializeField]
    public PlayerStatsInitialization _playerStatsInitialization;

    public void Initialize()
    {
        _model = new PlayerModel();

        _FSM = new PlayerFSM(this, _model);
        _FSM.InitializeState(new PlayerFSMState_Idle(_FSM));
        _FSM.InitializeState(new PlayerFSMState_Movement(_FSM));
        _FSM.InitializeState(new PlayerFSMState_Dash(_FSM));
        _FSM.InitializeState(new PlayerFSMState_BaseAttack(_FSM));
        _FSM.InitializeState(new PlayerFSMState_BaseAttackAwaitCombo(_FSM));
        _FSM.InitializeState(new PlayerFSMState_SwingAttack(_FSM));
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
}
