using UnityEngine;

public class EnemyFSMState : FSMState
{
    protected EnemyFSM _FSM;
    protected TransformController _transformController;
    //protected PlayerAnimatorController _animatorController;

    public EnemyFSMState(EnemyFSM FSM) : base()
    {
        _FSM = FSM;
        _transformController = _FSM.TransformController;
        //_animatorController = _FSM.AnimatorController;
    }
}
