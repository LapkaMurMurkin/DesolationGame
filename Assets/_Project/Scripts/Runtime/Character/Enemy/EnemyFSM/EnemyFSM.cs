<<<<<<< Updated upstream
using System.Collections.Generic;
=======
>>>>>>> Stashed changes
using UnityEngine;

public class EnemyFSM : FSM
{
    public Enemy Enemy;
<<<<<<< Updated upstream
    public EnemyModel EnemyModel;
    public Transform SpawnZoneTransform;
    public TransformController TransformController;

    public EnemyFSM(Enemy enemy, EnemyModel enemyModel, Transform spawnZoneTransform)
    {
        Enemy = enemy;
        EnemyModel = enemyModel;
        SpawnZoneTransform = spawnZoneTransform;
        TransformController = new TransformController(Enemy.transform);
=======
    public EnemyModel Model;
    public TransformController TransformController;
    public Animator Animator;
    public EnemyAnimatorController AnimatorController;
    public EnemyAnimatorEvents AnimatorEvents;

    public EnemyFSM(Enemy enemy, EnemyModel model)
    {
        Enemy = enemy;
        Model = model;
        TransformController = new TransformController(enemy.transform);
        Animator = Enemy.GetComponentInChildren<Animator>();
        AnimatorController = new EnemyAnimatorController(Animator);
        //AnimatorEvents = Player.GetComponentInChildren<PlayerAnimatorEvents>();
>>>>>>> Stashed changes
    }

    public override void Update()
    {
        base.Update();
<<<<<<< Updated upstream

=======
        TransformController.Update();
>>>>>>> Stashed changes
    }
}
