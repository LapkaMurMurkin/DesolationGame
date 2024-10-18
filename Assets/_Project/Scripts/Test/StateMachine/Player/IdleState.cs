using UnityEngine;

public class IdleState : BaseState
{
    public override void Enter()
    {
        base.Enter();

        Debug.Log("Enter in: IdleState");
    }

    public override void Exit()
    {
        base.Exit();

        Debug.Log("Exit from: Idle");
    }

}
