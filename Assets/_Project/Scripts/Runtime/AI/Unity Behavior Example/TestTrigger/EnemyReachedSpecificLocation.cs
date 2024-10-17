using System;
using Unity.Behavior.GraphFramework;
using Unity.Behavior;
using UnityEngine;
using Unity.Properties;

#if UNITY_EDITOR
[CreateAssetMenu(menuName = "Behavior/Event Channels/EnemyReachedSpecificLocation")]
#endif
[Serializable, GeneratePropertyBag]
[EventChannelDescription(name: "EnemyReachedSpecificLocation", message: "Agent reached specific location", category: "Events", id: "7fff2a1b54e2d9e5355b51922bbe49af")]
public partial class EnemyReachedSpecificLocation : EventChannelBase
{
    public delegate void EnemyReachedSpecificLocationEventHandler();
    public event EnemyReachedSpecificLocationEventHandler Event; 

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
        EnemyReachedSpecificLocationEventHandler del = () =>
        {
            callback();
        };
        return del;
    }

    public override void RegisterListener(Delegate del)
    {
        Event += del as EnemyReachedSpecificLocationEventHandler;
    }

    public override void UnregisterListener(Delegate del)
    {
        Event -= del as EnemyReachedSpecificLocationEventHandler;
    }
}

