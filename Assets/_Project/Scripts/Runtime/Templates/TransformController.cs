using System;
using System.Collections;
using System.Collections.Generic;
using R3;
using R3.Triggers;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class TransformController
{
    public Transform ObjectTransform;
    public Vector3 CurrentVelocityVector;
    public Vector3 TargetVelocityVector;
    public float VelocityTransitionDelta;
    public float VelocityTransitionDuration;

    public TransformController(Transform transform)
    {
        ObjectTransform = transform;
        CurrentVelocityVector = new Vector3();
        TargetVelocityVector = new Vector3();
        VelocityTransitionDelta = 0;
        VelocityTransitionDuration = 0;
    }

    public void Update()
    {
        CurrentVelocityVector = Vector3.MoveTowards(CurrentVelocityVector, TargetVelocityVector, VelocityTransitionDelta / VelocityTransitionDuration * Time.deltaTime);
        ObjectTransform.position += CurrentVelocityVector * Time.deltaTime;
        ObjectTransform.rotation = Quaternion.LookRotation(CurrentVelocityVector != Vector3.zero ? CurrentVelocityVector : ObjectTransform.forward);
    }

    public void AddAcceleration(float range, float duration)
    {
        float startSpeed = CurrentVelocityVector.magnitude;
        float acceleratio = (float)(2f * (range / Math.Pow(duration, 2)) - 2f * (startSpeed / duration));
        TargetVelocityVector = CurrentVelocityVector;
        CurrentVelocityVector = ObjectTransform.forward * (startSpeed + acceleratio * duration);
        VelocityTransitionDelta = Math.Abs((CurrentVelocityVector - TargetVelocityVector).magnitude);
        VelocityTransitionDuration = duration;
    }
}
