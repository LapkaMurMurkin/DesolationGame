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
    public PlayerTransformController TransformController;
    public Animator Animator;
    public PlayerAnimatorController AnimatorController;
    public PlayerAnimatorEvents AnimatorEvents;
    //public Raycaster Raycaster;

    public PlayerFSM(Player player, PlayerModel playerModel)
    {
        Player = player;
        Model = playerModel;
        TransformController = new PlayerTransformController(player.transform);
        Animator = Player.GetComponentInChildren<Animator>();
        AnimatorController = new PlayerAnimatorController(Animator);
        AnimatorEvents = Player.GetComponentInChildren<PlayerAnimatorEvents>();
        //Raycaster = ServiceLocator.Get<Raycaster>();
    }

    public override void Update()
    {
        base.Update();
        TransformController.Update();
    }
}
