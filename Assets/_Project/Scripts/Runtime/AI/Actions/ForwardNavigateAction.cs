using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Forward Navigate", story: "[Agent] navigates Forward at [distance]", category: "Action", id: "18d7f5b8b87e981f9e1722edb8d54ee5")]
public partial class ForwardNavigateAction : Action
{
    [SerializeReference] public BlackboardVariable<Transform> Agent;
    [SerializeReference] public BlackboardVariable<float> Distance;
    [SerializeReference] public BlackboardVariable<float> Speed = new BlackboardVariable<float>(1.0f);
    [SerializeReference] public BlackboardVariable<float> RayDistance = new BlackboardVariable<float>(1.0f);

    private Vector3 _targetPosition;
    private RaycastHit _raycastHit;

    protected override Status OnStart()
    {
        _targetPosition = Agent.Value.position + (Agent.Value.forward * Distance);

        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if (ReferenceEquals(Agent?.Value, null) || Distance is null)
        {
            return Status.Failure;
        }

        Vector3 agentPosition = Agent.Value.transform.position;
        Vector3 toDestination = _targetPosition - agentPosition;
        toDestination.Normalize();

        agentPosition += toDestination * (Speed * Time.deltaTime);
        Agent.Value.transform.position = agentPosition;

        if(Physics.Raycast(Agent.Value.transform.position, Agent.Value.forward, out _raycastHit, RayDistance))
        {
            if(_raycastHit.transform.GetComponent<Player>() != null)
                return Status.Success;
        }

        if((Agent.Value.transform.position - _targetPosition).magnitude >= 0.1f)
            return Status.Running;

        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

