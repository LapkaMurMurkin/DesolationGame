using UnityEngine;

public class EnemyFSM : FSM
{
    public Enemy Enemy;
    public EnemyModel Model;
    public TransformController TransformController;
    public Animator Animator;
    public EnemyAnimatorController AnimatorController;
    public EnemyAnimatorEvents AnimatorEvents;

    public Transform SpawnZoneTransform;

    public EnemyFSM(Enemy enemy, EnemyModel model)
    {
        Enemy = enemy;
        Model = model;
        TransformController = new TransformController(enemy.transform);
        Animator = Enemy.GetComponentInChildren<Animator>();
        AnimatorController = new EnemyAnimatorController(Animator);
        //AnimatorEvents = Player.GetComponentInChildren<PlayerAnimatorEvents>();
    }

    public override void Update()
    {
        base.Update();
        //TransformController.Update();
    }
}
