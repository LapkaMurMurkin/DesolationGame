using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private IStateMachine _stateMachine;
    private ActionMap _inputActions;

    private bool _isDashing;
    private float _dashColldownTime = 1f;

    public void Init(IStateMachine stateMachine, ActionMap inputActions)
    {
        _stateMachine = stateMachine;
    
        _inputActions = inputActions;
    
        _inputActions.Player.Movement.performed += ctx => OnMoveInputChanged(ctx.ReadValue<Vector2>());
        _inputActions.Player.Movement.canceled += ctx => OnMoveInputChanged(ctx.ReadValue<Vector2>());
        _inputActions.Player.Dash.performed += ctx => DashPerformed();
    }

    private void OnDestroy()
    {
        _inputActions.Player.Movement.performed -= ctx => OnMoveInputChanged(ctx.ReadValue<Vector2>());
        _inputActions.Player.Movement.canceled -= ctx => OnMoveInputChanged(ctx.ReadValue<Vector2>());
        _inputActions.Player.Dash.performed -= ctx => DashPerformed();
    }

    private void Update()
    {
        _stateMachine.Update();
    }


    private void OnMoveInputChanged(Vector2 input)
    {
        if(input != Vector2.zero)
            _stateMachine.Apply(new UserInput() { IsMoving = true });
        else
            _stateMachine.Apply(new UserInput() { IsMoving = false });
    }

    private void DashPerformed()
    {
        if(!_isDashing)
        {
            StartCoroutine(DashCooldown());
        }
    }

    private IEnumerator DashCooldown()
    {
        _isDashing = true;
        _stateMachine.Apply(new DashContext() { IsDashPerformed = true });

        yield return new WaitForSeconds(_dashColldownTime);

        _stateMachine.Apply(new DashContext() { IsDashPerformed = false });
        _isDashing = false;
    }

}
