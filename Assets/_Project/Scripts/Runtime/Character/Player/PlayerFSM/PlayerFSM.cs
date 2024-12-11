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
    public TransformController TransformController;
    public Animator Animator;
    public PlayerAnimatorController AnimatorController;
    public PlayerAnimatorEvents AnimatorEvents;

    public PlayerFSM(Player player, PlayerModel model)
    {
        Player = player;
        Model = model;
        TransformController = new TransformController(player.transform);
        Animator = Player.GetComponentInChildren<Animator>();
        AnimatorController = new PlayerAnimatorController(Animator);
        AnimatorEvents = Player.GetComponentInChildren<PlayerAnimatorEvents>();
    }

    public override void Update()
    {
        base.Update();
        TransformController.MoveAlongVelocityVector();
    }
}
