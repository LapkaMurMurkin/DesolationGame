using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Perform Forward Attack", story: "[Agent] attacks [Target]", category: "Action", id: "632183d3804a7f2dac77a7c76e142857")]
public partial class PerformForwardAttackAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Agent;
    // [SerializeReference] public BlackboardVariable<GameObject> Target;
    [SerializeReference] public BlackboardVariable<float> RayDistance;
    [SerializeReference] public BlackboardVariable<float> Damage;

    private RaycastHit _raycastHit;

    protected override Status OnStart()
    {
        if(Physics.Raycast(Agent.Value.transform.position, Agent.Value.transform.forward * RayDistance, out _raycastHit))
        {
            if(_raycastHit.transform.TryGetComponent(out PlayerDamageableComponent playerDamageableComponent))
            {
                playerDamageableComponent.ApplyDamage(Damage);
            }
        }
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

