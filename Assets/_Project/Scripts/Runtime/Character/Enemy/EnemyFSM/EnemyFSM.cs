using System.Collections.Generic;
using UnityEngine;

public class EnemyFSM : FSM
{
    public Enemy Enemy;
    public EnemyModel EnemyModel;
    public Transform SpawnZoneTransform;
    public TransformController TransformController;

    public EnemyFSM(Enemy enemy, EnemyModel enemyModel, Transform spawnZoneTransform)
    {
        Enemy = enemy;
        EnemyModel = enemyModel;
        SpawnZoneTransform = spawnZoneTransform;
        TransformController = new TransformController(Enemy.transform);
    }

    public override void Update()
    {
        base.Update();

    }
}
