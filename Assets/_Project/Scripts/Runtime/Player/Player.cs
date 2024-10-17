using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerModel _model;

    private PlayerFSM _FSM;

    public void Initialize()
    {
        _model = new PlayerModel();

        _FSM = new PlayerFSM(this, _model);
        _FSM.InitializeState(new PlayerFSMState_Idle(_FSM));
        _FSM.InitializeState(new PlayerFSMState_Movement(_FSM));
        _FSM.InitializeState(new PlayerFSMState_Dash(_FSM));
        _FSM.InitializeState(new PlayerFSMState_Attack(_FSM));
        _FSM.InitializeState(new PlayerFSMState_SwingAttack(_FSM));
        _FSM.SwitchStateTo<PlayerFSMState_Idle>();
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
