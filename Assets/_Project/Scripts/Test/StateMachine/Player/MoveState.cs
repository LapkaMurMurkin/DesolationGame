using UnityEngine;
using UnityEngine.InputSystem;

public class MoveState : BaseState
{
    private readonly CharacterController _controller;
    private readonly InputAction _moveInputAction;
    private Vector3 _currentVelocityVector;
    private Vector3 _currentVelocity;
    private float _smoothMoveDeltaTime = 0.2f; // from config
    float currentMoveSpeed = 7f; // from config

    public MoveState(CharacterController controller, InputAction moveInputAction)
    {
        _controller = controller;
        _moveInputAction = moveInputAction;
    }

    public override void Enter()
    {
        base.Enter();

        Debug.Log("In Move STATE");
    }

    public override void Update()
    {
        base.Update();
        Move();
    }

    public override void Exit()
    {
        base.Exit();

        Debug.Log("EXIT MOVE(");
    }

    public void Move()
    {
        Vector2 moveDirection = _moveInputAction.ReadValue<Vector2>();
        Vector3 moveVector = _controller.transform.TransformDirection(new Vector3(moveDirection.x, 0, moveDirection.y)).normalized;

        _currentVelocityVector = Vector3.SmoothDamp(_currentVelocityVector, moveVector * currentMoveSpeed, ref _currentVelocity, _smoothMoveDeltaTime);

        _controller.transform.rotation = Quaternion.RotateTowards(_controller.transform.rotation, Quaternion.LookRotation(moveVector), 180 / 0.2f * Time.deltaTime);

        _controller.Move(_currentVelocityVector * Time.deltaTime);
    }
}
