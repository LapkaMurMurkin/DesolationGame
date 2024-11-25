using System;
using Unity.Behavior.GraphFramework;
using Unity.Behavior;
using UnityEngine;
using Unity.Properties;

#if UNITY_EDITOR
[CreateAssetMenu(menuName = "Behavior/Event Channels/Agent Hit")]
#endif
[Serializable, GeneratePropertyBag]
[EventChannelDescription(name: "Agent Hit", message: "[Agent] was hit", category: "Events", id: "ccb945be62282a128c9a37a3b458c449")]
public partial class AgentHit : EventChannelBase
{
    public delegate void AgentHitEventHandler(Transform Agent);
    public event AgentHitEventHandler Event; 

    public void SendEventMessage(Transform Agent)
    {
        Event?.Invoke(Agent);
    }

    public override void SendEventMessage(BlackboardVariable[] messageData)
    {
        BlackboardVariable<Transform> AgentBlackboardVariable = messageData[0] as BlackboardVariable<Transform>;
        var Agent = AgentBlackboardVariable != null ? AgentBlackboardVariable.Value : default(Transform);

        Event?.Invoke(Agent);
    }

    public override Delegate CreateEventHandler(BlackboardVariable[] vars, System.Action callback)
    {
        AgentHitEventHandler del = (Agent) =>
        {
            BlackboardVariable<Transform> var0 = vars[0] as BlackboardVariable<Transform>;
            if(var0 != null)
                var0.Value = Agent;

            callback();
        };
        return del;
    }

    public override void RegisterListener(Delegate del)
    {
        Event += del as AgentHitEventHandler;
    }

    public override void UnregisterListener(Delegate del)
    {
        Event -= del as AgentHitEventHandler;
    }
}

