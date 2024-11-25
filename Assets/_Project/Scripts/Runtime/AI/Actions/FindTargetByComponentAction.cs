using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Find Target by Component", story: "Find [Target] with [Component]", category: "Action", id: "e5a78a5dff65e5e5f4c0b3a02218c51c")]
public partial class FindTargetByComponentAction : Action
{
    [SerializeReference] public BlackboardVariable<Transform> Target;
    [SerializeReference] public BlackboardVariable<MonoBehaviour> Component;

    protected override Status OnStart()
    {
        Target.Value = GameObject.FindFirstObjectByType(typeof(Component)) as Transform;
        return Status.Success;
    }

    protected override Status OnUpdate()
    {
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

