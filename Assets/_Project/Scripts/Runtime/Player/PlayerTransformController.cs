using System;
using System.Collections;
using System.Collections.Generic;
using R3;
using R3.Triggers;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTransformController
{
    public Transform PlayerTransform;
    public Vector3 CurrentVelocityVector;
    public Vector3 TargetVelocityVector;
    public float VelocityTransitionDelta;
    public float VelocityTransitionDuration;

    public ReadOnlyReactiveProperty<Vector3> CurrentVelocityVectorView;

    public PlayerTransformController(Transform playerTransform)
    {
        PlayerTransform = playerTransform;
        CurrentVelocityVector = new Vector3();
        TargetVelocityVector = new Vector3();
        VelocityTransitionDelta = 0;
        VelocityTransitionDuration = 0;
    }

    public void Update()
    {
        CurrentVelocityVector = Vector3.MoveTowards(CurrentVelocityVector, TargetVelocityVector, VelocityTransitionDelta / VelocityTransitionDuration * Time.deltaTime);
        PlayerTransform.position += CurrentVelocityVector * Time.deltaTime;
        PlayerTransform.rotation = Quaternion.LookRotation(CurrentVelocityVector != Vector3.zero ? CurrentVelocityVector : PlayerTransform.forward);
    }

    public void AddAcceleration(float range, float duration)
    {
        float startSpeed = CurrentVelocityVector.magnitude;
        float acceleratio = (float)(2f * (range / Math.Pow(duration, 2)) - 2f * (startSpeed / duration));
        TargetVelocityVector = CurrentVelocityVector;
        CurrentVelocityVector = PlayerTransform.forward * (startSpeed + acceleratio * duration);
        VelocityTransitionDelta = Math.Abs((CurrentVelocityVector - TargetVelocityVector).magnitude);
        VelocityTransitionDuration = duration;

/*         Debug.Log("startSpeed " + startSpeed);
        Debug.Log("acceleratio " + acceleratio);
        Debug.Log("TargetVelocityVector " + TargetVelocityVector);
        Debug.Log("CurrentVelocityVector " + CurrentVelocityVector);
        Debug.Log("VelocityTransitionDelta " + VelocityTransitionDelta);
        Debug.Log("VelocityTransitionDuration " + VelocityTransitionDuration); */
    }
}
