<<<<<<< Updated upstream
using System;
using R3;
using R3.Triggers;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class Enemy : MonoBehaviour
{
    private EnemyModel _enemyModel;
    private EnemyFSM _FSM;

    public static Action<Enemy> OnDeath;

    public void Initialize(Transform spawnZoneTransform)
    {
        _enemyModel = new EnemyModel();
        _FSM = new EnemyFSM(this, _enemyModel, spawnZoneTransform);
        //_FSM.InitializeState(new EnemyFSMState_Idle(_FSM));
        _FSM.InitializeState(new EnemyFSMState_Patrol(_FSM));
        _FSM.InitializeState(new EnemyFSMState_Aggro(_FSM));

        _FSM.SwitchStateTo<EnemyFSMState_Patrol>();
=======
using UnityEngine;

public class Enemy : Character
{
    private EnemyModel _model;
    private EnemyView _view;

    private EnemyFSM _FSM;

    public void Initialize()
    {
        _model = new EnemyModel();
        //_model.Initialize(_playerStatsInitialization);
        _view = GetComponent<EnemyView>();
        //_view.Initialize(_model);

        _FSM = new EnemyFSM(this, _model);
/*         _FSM.InitializeState(new PlayerFSMState_Idle(_FSM));
        _FSM.InitializeState(new PlayerFSMState_Movement(_FSM));
        _FSM.InitializeState(new PlayerFSMState_Dash(_FSM));
        _FSM.InitializeState(new PlayerFSMState_BaseAttack(_FSM));
        _FSM.InitializeState(new PlayerFSMState_BaseAttackAwaitCombo(_FSM));
        _FSM.InitializeState(new PlayerFSMState_SwingAttack(_FSM));
        _FSM.SwitchStateTo<PlayerFSMState_Idle>(); */
>>>>>>> Stashed changes
    }

    private void Update()
    {
        _FSM.Update();
    }
<<<<<<< Updated upstream

    private void OnTriggerEnter(Collider collider)
    {
        Player player = collider.GetComponent<Player>();
        //PlayerWeapon playerWeapon = collider.GetComponent<PlayerWeapon>();

        if (player is not null)
        {
            Destroy(this.gameObject);
            player.ApplyDamage(10);
            Debug.Log("Damage 10!");
        }

        /*         if(playerWeapon is not null)
                {
                    OnDeath!.Invoke(this);
                    Debug.Log("Enemy killed");
                } */
    }
=======
>>>>>>> Stashed changes
}
