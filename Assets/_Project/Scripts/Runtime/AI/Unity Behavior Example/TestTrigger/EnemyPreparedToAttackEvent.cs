using System;
using Unity.Behavior.GraphFramework;
using Unity.Behavior;
using UnityEngine;
using Unity.Properties;

#if UNITY_EDITOR
[CreateAssetMenu(menuName = "Behavior/Event Channels/EnemyPreparedToAttack")]
#endif
[Serializable, GeneratePropertyBag]
[EventChannelDescription(name: "EnemyPreparedToAttack", message: "Enemy prepared to Attack", category: "Events", id: "d9842ee2a7527c274a2acedee99d22d7")]
public partial class EnemyPreparedToAttackEvent : EventChannelBase
{
    public delegate void EnemyPreparedToAttackEventHandler();
    public event EnemyPreparedToAttackEventHandler Event; 

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
        EnemyPreparedToAttackEventHandler del = () =>
        {
            callback();
        };
        return del;
    }

    public override void RegisterListener(Delegate del)
    {
        Event += del as EnemyPreparedToAttackEventHandler;
    }

    public override void UnregisterListener(Delegate del)
    {
        Event -= del as EnemyPreparedToAttackEventHandler;
    }
}

