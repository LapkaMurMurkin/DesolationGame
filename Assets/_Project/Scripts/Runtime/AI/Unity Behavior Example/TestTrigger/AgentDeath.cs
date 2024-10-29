using System;
using Unity.Behavior.GraphFramework;
using Unity.Behavior;
using UnityEngine;
using Unity.Properties;

#if UNITY_EDITOR
[CreateAssetMenu(menuName = "Behavior/Event Channels/Agent Death")]
#endif
[Serializable, GeneratePropertyBag]
[EventChannelDescription(name: "Agent Death", message: "[Agent] Dead", category: "Events", id: "25de29e7e76260e2074ac3daed651e84")]
public partial class AgentDeath : EventChannelBase
{
    public delegate void AgentDeathEventHandler(GameObject Agent);
    public event AgentDeathEventHandler Event; 

    public void SendEventMessage(GameObject Agent)
    {
        Event?.Invoke(Agent);
    }

    public override void SendEventMessage(BlackboardVariable[] messageData)
    {
        BlackboardVariable<GameObject> AgentBlackboardVariable = messageData[0] as BlackboardVariable<GameObject>;
        var Agent = AgentBlackboardVariable != null ? AgentBlackboardVariable.Value : default(GameObject);

        Event?.Invoke(Agent);
    }

    public override Delegate CreateEventHandler(BlackboardVariable[] vars, System.Action callback)
    {
        AgentDeathEventHandler del = (Agent) =>
        {
            BlackboardVariable<GameObject> var0 = vars[0] as BlackboardVariable<GameObject>;
            if(var0 != null)
                var0.Value = Agent;

            callback();
        };
        return del;
    }

    public override void RegisterListener(Delegate del)
    {
        Event += del as AgentDeathEventHandler;
    }

    public override void UnregisterListener(Delegate del)
    {
        Event -= del as AgentDeathEventHandler;
    }
}

