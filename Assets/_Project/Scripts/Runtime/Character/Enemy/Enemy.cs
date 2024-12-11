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
    }

    private void Update()
    {
        _FSM.Update();
    }

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
}
