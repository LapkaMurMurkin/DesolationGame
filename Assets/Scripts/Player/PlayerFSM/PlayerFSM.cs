using System.Collections;
using System.Collections.Generic;
using R3;
using R3.Triggers;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerFSM : FSM
{
    public Player Player;
    public PlayerModel Model;
    public Animator Animator;
    public AnimatorController AnimatorController;
    public PlayerAnimatorEvents PlayerAnimatorEvents;

    public InputAction Movement;
    public InputAction Dash;
    public InputAction Attack;

    public Vector2 MovementInput;
    public Vector3 MovementDirection;
    public Vector3 CurrentVelocityVector;
    public Vector3 TargetVelocityVector;
    public float Speed = 5f;
    public float StartTime = 0.1f;
    public float StopTime = 0.3f;

    public float DashAcceleration = 3f;
    public float DashDecelerationTime = 0.5f;

    public PlayerFSM(Player player, PlayerModel playerModel)
    {
        Player = player;
        Model = playerModel;
        Animator = Player.GetComponentInChildren<Animator>();
        AnimatorController = new AnimatorController(Animator);
        PlayerAnimatorEvents = Player.GetComponentInChildren<PlayerAnimatorEvents>();

        ActionMap actionMap = ServiceLocator.Get<ActionMap>();
        Movement = actionMap.Player.Movement;
        Dash = actionMap.Player.Dash;
        Attack = actionMap.Player.Attack;
    }
}
