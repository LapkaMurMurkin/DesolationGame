using System;
using Unity.Behavior.GraphFramework;
using Unity.Behavior;
using UnityEngine;
using Unity.Properties;

#if UNITY_EDITOR
[CreateAssetMenu(menuName = "Behavior/Event Channels/AgentDamaged")]
#endif
[Serializable, GeneratePropertyBag]
[EventChannelDescription(name: "AgentDamaged", message: "[Agent] was damaged in [value]", category: "Events", id: "4906709c2ad4dc49b82c18209ccfb415")]
public partial class AgentDamaged : EventChannelBase
{
    public delegate void AgentDamagedEventHandler(GameObject Agent, float value);
    public event AgentDamagedEventHandler Event; 

    public void SendEventMessage(GameObject Agent, float value)
    {
        Event?.Invoke(Agent, value);
    }

    public override void SendEventMessage(BlackboardVariable[] messageData)
    {
        BlackboardVariable<GameObject> AgentBlackboardVariable = messageData[0] as BlackboardVariable<GameObject>;
        var Agent = AgentBlackboardVariable != null ? AgentBlackboardVariable.Value : default(GameObject);

        BlackboardVariable<float> valueBlackboardVariable = messageData[1] as BlackboardVariable<float>;
        var value = valueBlackboardVariable != null ? valueBlackboardVariable.Value : default(float);

        Event?.Invoke(Agent, value);
    }

    public override Delegate CreateEventHandler(BlackboardVariable[] vars, System.Action callback)
    {
        AgentDamagedEventHandler del = (Agent, value) =>
        {
            BlackboardVariable<GameObject> var0 = vars[0] as BlackboardVariable<GameObject>;
            if(var0 != null)
                var0.Value = Agent;

            BlackboardVariable<float> var1 = vars[1] as BlackboardVariable<float>;
            if(var1 != null)
                var1.Value = value;

            callback();
        };
        return del;
    }

    public override void RegisterListener(Delegate del)
    {
        Event += del as AgentDamagedEventHandler;
    }

    public override void UnregisterListener(Delegate del)
    {
        Event -= del as AgentDamagedEventHandler;
    }
}

