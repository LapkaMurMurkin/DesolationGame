using UnityEngine;

public class DashState : BaseState
{

    public override void Enter()
    {
        base.Enter();

        Debug.Log("Enter IN Dash STATE");
    }

    public override void Exit()
    {
        base.Exit();

        Debug.Log("EXIT Dash");
    }

}
