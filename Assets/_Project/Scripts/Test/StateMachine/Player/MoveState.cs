using UnityEngine;

public class MoveState : BaseState
{
    public override void Enter()
    {
        base.Enter();

        Debug.Log("In Move STATE");
    }

    public override void Exit()
    {
        base.Exit();

        Debug.Log("EXIT MOVE(");
    }
}
