using UnityEngine;

public class EnemyAnimatorController : AnimatorController
{
    public const string IDLE_ANIM_NAME = "Idle";
    public const string WALK_ANIM_NAME = "Walk";
    public const string DEATH_ANIM_NAME = "Death";
    public const string RAM_PREPARE_ANIM_NAME = "RamPrepare";
    public const string RAM_ANIM_NAME = "Ram";
    
    /*     public const string RUN_ANIM_NAME = "Run";
        public const string DASH_ANIM_NAME = "Dash";
        public const string BASE_ATTACK_1_ANIM_NAME = "BaseAttack_1";
        public const string BASE_ATTACK_AWAIT_COMBO_1_ANIM_NAME = "BaseAttackAwaitCombo_1";
        public const string BASE_ATTACK_END_1_ANIM_NAME = "BaseAttackEnd_1";
        public const string BASE_ATTACK_2_ANIM_NAME = "BaseAttack_2";
        public const string BASE_ATTACK_AWAIT_COMBO_2_ANIM_NAME = "BaseAttackAwaitCombo_2";
        public const string BASE_ATTACK_END_2_ANIM_NAME = "BaseAttackEnd_2";
        public const string BASE_ATTACK_3_ANIM_NAME = "BaseAttack_3";
        public const string BASE_ATTACK_END_3_ANIM_NAME = "BaseAttackEnd_3";
        public const string DEATH_ANIM_NAME = "Death";

        public const string ATTACK_SPEED_VAR = "AttackSpeed"; */

    public EnemyAnimatorController(Animator animator) : base(animator)
    {
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
