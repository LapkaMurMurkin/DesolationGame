using System;
using Unity.Behavior.GraphFramework;
using Unity.Behavior;
using UnityEngine;
using Unity.Properties;

#if UNITY_EDITOR
[CreateAssetMenu(menuName = "Behavior/Event Channels/EnemyPerformAttackEvent")]
#endif
[Serializable, GeneratePropertyBag]
[EventChannelDescription(name: "EnemyPerformAttackEvent", message: "Agent Perform Attack", category: "Events", id: "32a8749c348b42650a4cd268afa050aa")]
public partial class EnemyPerformAttackEvent : EventChannelBase
{
    public delegate void EnemyPerformAttackEventEventHandler();
    public event EnemyPerformAttackEventEventHandler Event; 

    public void SendEventMessage()
    {
        Event?.Invoke();
    }

    public override void SendEventMessage(BlackboardVariable[] messageData)
    {
        Event?.Invoke();
    }

    public override Delegate CreateEventHandler(BlackboardVariable[] vars, System.Action callback)
    {
        EnemyPerformAttackEventEventHandler del = () =>
        {
            callback();
        };
        return del;
    }

    public override void RegisterListener(Delegate del)
    {
        Event += del as EnemyPerformAttackEventEventHandler;
    }

    public override void UnregisterListener(Delegate del)
    {
        Event -= del as EnemyPerformAttackEventEventHandler;
    }
}

