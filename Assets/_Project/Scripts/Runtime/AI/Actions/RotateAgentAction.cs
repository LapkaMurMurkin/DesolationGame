using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "RotateAgent", story: "[Agent] Rotates to [Target]", category: "Action", id: "806b54cea2e22b4cbf983fe913d11580")]
public partial class RotateAgentAction : Action
{
    [SerializeReference] public BlackboardVariable<Transform> Agent;
    [SerializeReference] public BlackboardVariable<Transform> Target;
    [SerializeReference] public BlackboardVariable<float> RotateSpeed = new BlackboardVariable<float>(1.0f);

    private Vector3 _targetPositionToRotate;

    protected override Status OnStart()
    {
        _targetPositionToRotate = Target.Value.position;
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        Vector3 directionToTarget = _targetPositionToRotate - Agent.Value.position;
        directionToTarget.y = 0;

        Agent.Value.rotation = Quaternion.LookRotation(directionToTarget);

        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

