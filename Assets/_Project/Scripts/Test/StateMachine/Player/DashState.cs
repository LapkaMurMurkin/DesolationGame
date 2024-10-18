using UnityEngine;

public class DashState : BaseState
{
    private readonly CharacterController _controller;
    private Vector3 _currentVelocityVector;

    private float _dashAcceleration = 15f;
    private float _dashDeceleration = 1f;
    private float _speed = 7f;

    public DashState(CharacterController controller)
    {
        _controller = controller;
    }

    public override void Enter()
    {
        base.Enter();
        
        _currentVelocityVector =  _controller.transform.forward * _dashAcceleration;
        Debug.Log("Enter IN Dash STATE");
    }

    public override void Exit()
    {
        base.Exit();

        Debug.Log("EXIT Dash");
    }

    public override void Update()
    {
        base.Update();
        _currentVelocityVector = Vector3.MoveTowards(_currentVelocityVector, _currentVelocityVector * _speed, _dashAcceleration / _dashDeceleration * Time.deltaTime);
        _controller.Move(_currentVelocityVector * Time.deltaTime);
        
    }

}
