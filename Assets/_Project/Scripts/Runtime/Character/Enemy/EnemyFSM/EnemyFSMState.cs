using UnityEngine;

public class EnemyFSMState : FSMState
{
    protected EnemyFSM _FSM;
    protected TransformController _transformController;
<<<<<<< Updated upstream
    //protected PlayerAnimatorController _animatorController;
=======
    protected EnemyAnimatorController _animatorController;
>>>>>>> Stashed changes

    public EnemyFSMState(EnemyFSM FSM) : base()
    {
        _FSM = FSM;
        _transformController = _FSM.TransformController;
<<<<<<< Updated upstream
        //_animatorController = _FSM.AnimatorController;
=======
        _animatorController = _FSM.AnimatorController;
>>>>>>> Stashed changes
    }
}
