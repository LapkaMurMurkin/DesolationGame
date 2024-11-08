using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using UnityEngine.AI;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Forward Navigate", story: "[Agent] navigates Forward at [distance]", category: "Action", id: "18d7f5b8b87e981f9e1722edb8d54ee5")]
public partial class ForwardNavigateAction : Action
{
    [SerializeReference] public BlackboardVariable<NavMeshAgent> Agent;
    [SerializeReference] public BlackboardVariable<Transform> Self;
    [SerializeReference] public BlackboardVariable<float> Distance;
    [SerializeReference] public BlackboardVariable<float> Speed = new BlackboardVariable<float>(1.0f);
    [SerializeReference] public BlackboardVariable<float> RayDistance = new BlackboardVariable<float>(1.0f);

    private Vector3 _targetPosition;
    private RaycastHit _raycastHit;

    protected override Status OnStart()
    {
        _targetPosition = Self.Value.position + (Self.Value.forward * Distance);
        Agent.Value.speed = Speed;

        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if (ReferenceEquals(Agent?.Value, null) || Distance is null)
        {
            return Status.Failure;
        }

        Vector3 agentPosition = Self.Value.position;
        Vector3 toDestination = _targetPosition - agentPosition;
        toDestination.Normalize();

        agentPosition += toDestination * (Speed * Time.deltaTime);
        // Agent.Value.transform.position = agentPosition;
        Agent.Value.SetDestination(agentPosition);

        if(Physics.Raycast(Self.Value.position, Self.Value.forward, out _raycastHit, RayDistance))
        {
            if(_raycastHit.transform.GetComponent<Player>() != null)
                return Status.Success;
        }

        if((Self.Value.position - _targetPosition).magnitude >= 0.1f)
            return Status.Running;

        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

