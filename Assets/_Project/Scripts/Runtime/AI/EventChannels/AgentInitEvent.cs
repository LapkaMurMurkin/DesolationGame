using System;
using Unity.Behavior.GraphFramework;
using Unity.Behavior;
using UnityEngine;
using Unity.Properties;

#if UNITY_EDITOR
[CreateAssetMenu(menuName = "Behavior/Event Channels/AgentInitEvent")]
#endif
[Serializable, GeneratePropertyBag]
[EventChannelDescription(name: "AgentInitEvent", message: "[Agent] was inited with [Origin]", category: "Events", id: "77c60dbbd1749910206edd1ecda782fb")]
public partial class AgentInitEvent : EventChannelBase
{
    public delegate void AgentInitEventEventHandler(GameObject Agent, Transform Origin);
    public event AgentInitEventEventHandler Event; 

    public void SendEventMessage(GameObject Agent, Transform Origin)
    {
        Event?.Invoke(Agent, Origin);
    }

    public override void SendEventMessage(BlackboardVariable[] messageData)
    {
        BlackboardVariable<GameObject> AgentBlackboardVariable = messageData[0] as BlackboardVariable<GameObject>;
        var Agent = AgentBlackboardVariable != null ? AgentBlackboardVariable.Value : default(GameObject);

        BlackboardVariable<Transform> OriginBlackboardVariable = messageData[1] as BlackboardVariable<Transform>;
        var Origin = OriginBlackboardVariable != null ? OriginBlackboardVariable.Value : default(Transform);

        Event?.Invoke(Agent, Origin);
    }

    public override Delegate CreateEventHandler(BlackboardVariable[] vars, System.Action callback)
    {
        AgentInitEventEventHandler del = (Agent, Origin) =>
        {
            BlackboardVariable<GameObject> var0 = vars[0] as BlackboardVariable<GameObject>;
            if(var0 != null)
                var0.Value = Agent;

            BlackboardVariable<Transform> var1 = vars[1] as BlackboardVariable<Transform>;
            if(var1 != null)
                var1.Value = Origin;

            callback();
        };
        return del;
    }

    public override void RegisterListener(Delegate del)
    {
        Event += del as AgentInitEventEventHandler;
    }

    public override void UnregisterListener(Delegate del)
    {
        Event -= del as AgentInitEventEventHandler;
    }
}

