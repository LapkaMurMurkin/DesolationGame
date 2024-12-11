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
<<<<<<< Updated upstream

    public PlayerFSM(Player player, PlayerModel model)
    {
        Player = player;
        Model = model;
=======
    //public Raycaster Raycaster;

    public PlayerFSM(Player player, PlayerModel playerModel)
    {
        Player = player;
        Model = playerModel;
>>>>>>> Stashed changes
        TransformController = new TransformController(player.transform);
        Animator = Player.GetComponentInChildren<Animator>();
        AnimatorController = new PlayerAnimatorController(Animator);
        AnimatorEvents = Player.GetComponentInChildren<PlayerAnimatorEvents>();
<<<<<<< Updated upstream
=======
        //Raycaster = ServiceLocator.Get<Raycaster>();
>>>>>>> Stashed changes
    }

    public override void Update()
    {
        base.Update();
<<<<<<< Updated upstream
        TransformController.MoveAlongVelocityVector();
=======
        TransformController.Update();
>>>>>>> Stashed changes
    }
}
