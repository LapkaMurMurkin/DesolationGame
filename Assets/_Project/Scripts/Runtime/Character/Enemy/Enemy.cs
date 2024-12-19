using UnityEngine;

public class Enemy : Character
{
    private EnemyModel _model;
    private EnemyView _view;

    private EnemyFSM _FSM;

    public void Initialize(Transform spawnZoneTransform)
    {
        _model = new EnemyModel();
        _model.Initialize();
        _view = GetComponent<EnemyView>();
        //_view.Initialize(_model);

        _FSM = new EnemyFSM(this, _model);
        _FSM.SpawnZoneTransform = spawnZoneTransform;
        //_FSM.InitializeState(new EnemyFSMState_Idle(_FSM));
        _FSM.InitializeState(new EnemyFSMState_Patrol(_FSM));
        _FSM.InitializeState(new EnemyFSMState_Aggro(_FSM));
        _FSM.InitializeState(new EnemyFSMState_Ram(_FSM));
        _FSM.InitializeState(new EnemyFSMState_Death(_FSM));

        _FSM.SwitchStateTo<EnemyFSMState_Patrol>();
    }

    private void Update()
    {
        _FSM.Update();
    }

    public void ApplyDamage(float damage)
    {
        _model.CurrentHealth.Value -= (int)damage;
        Debug.Log($"Enemy - damage: {damage}");

        if (_model.CurrentHealth.Value <= 0 && _FSM.CurrentState is not EnemyFSMState_Death)
            _FSM.SwitchStateTo<EnemyFSMState_Death>();
    }
}
