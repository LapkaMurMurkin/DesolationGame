using System;
using System.Collections;
using System.Collections.Generic;
using R3;
using R3.Triggers;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class TransformController
{
    public Transform ObjectTransform;
    public Vector3 CurrentVelocityVector;
    public Vector3 TargetVelocityVector;
    public float VelocityTransitionDelta;
    public float VelocityTransitionDuration;

    //public NavMeshAgent NavMeshAgent;

    public TransformController(Transform transform)
    {
        ObjectTransform = transform;
        CurrentVelocityVector = new Vector3();
        TargetVelocityVector = new Vector3();
        VelocityTransitionDelta = 0;
        VelocityTransitionDuration = 0;

        //NavMeshAgent = transform.GetComponent<NavMeshAgent>();
    }

    public void MoveAlongVelocityVector()
    {
        CurrentVelocityVector = Vector3.MoveTowards(CurrentVelocityVector, TargetVelocityVector, VelocityTransitionDelta / VelocityTransitionDuration * Time.deltaTime);
        ObjectTransform.position += CurrentVelocityVector * Time.deltaTime;
        //NavMeshAgent.Move(CurrentVelocityVector * Time.deltaTime);
        ObjectTransform.rotation = Quaternion.LookRotation(CurrentVelocityVector != Vector3.zero ? CurrentVelocityVector : ObjectTransform.forward);
    }

    public void AddStraightAcceleration(float range, float duration)
    {
        float startSpeed = CurrentVelocityVector.magnitude;
        float acceleration = (float)(2f * (range / Math.Pow(duration, 2)) - 2f * (startSpeed / duration));
        TargetVelocityVector = CurrentVelocityVector;
        CurrentVelocityVector = ObjectTransform.forward * (startSpeed + acceleration * duration);
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
