using System;
using Unity.Behavior;
using UnityEngine;
using UnityEngine.AI;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using Random = UnityEngine.Random;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Patrol In Zone", story: "[Agent] Patrols around [Origin]", category: "Action", id: "11fb23d59e9de4a266d537b0abc19fe4")]
public partial class PatrolInZoneAction : Action
{
    [SerializeReference] public BlackboardVariable<NavMeshAgent> Agent;
    [SerializeReference] public BlackboardVariable<Transform> Origin;
    [SerializeReference] public BlackboardVariable<float> Speed;
    [SerializeReference, Min(0)] public BlackboardVariable<float> MinDistanceToWaypoint;
    private Vector3 position;
    private float _stopDistance;

    protected override Status OnStart()
    {
        // Agent.Value.stoppingDistance = _stopDistance;
        Agent.Value.speed = Speed;
        SetNewPosition();
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if(Vector3.Distance(Agent.Value.transform.position, position) < MinDistanceToWaypoint)
        {
            SetNewPosition();
        }
        
        return Status.Running;
    }

    protected override void OnEnd()
    {
        if (Agent.Value != null)
        {
            if (Agent.Value.isOnNavMesh)
            {
                Agent.Value.ResetPath();
            }
            // Agent.Value.stoppingDistance = _stopDistance;
        }
    }

    private void SetNewPosition()
    {
        if(Origin != null)
            position = Origin.Value.position + Random.onUnitSphere * Origin.Value.localScale.x;
        else
            position = Vector3.zero;

        position.y = Agent.Value.transform.localScale.y;
        Agent.Value.SetDestination(position);
    }
}

