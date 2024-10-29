using System;
using Unity.Behavior.GraphFramework;
using Unity.Behavior;
using UnityEngine;
using Unity.Properties;

#if UNITY_EDITOR
[CreateAssetMenu(menuName = "Behavior/Event Channels/EnemyExit The Trigger")]
#endif
[Serializable, GeneratePropertyBag]
[EventChannelDescription(name: "EnemyExit The Trigger", message: "[Enemy] has Exit the Spot", category: "Events", id: "142f329286268e5a8f07a13759079c84")]
public partial class EnemyExitTheTrigger : EventChannelBase
{
    public delegate void EnemyExitTheTriggerEventHandler(GameObject Enemy);
    public event EnemyExitTheTriggerEventHandler Event; 

    public void SendEventMessage(GameObject Enemy)
    {
        Event?.Invoke(Enemy);
    }

    public override void SendEventMessage(BlackboardVariable[] messageData)
    {
        BlackboardVariable<GameObject> EnemyBlackboardVariable = messageData[0] as BlackboardVariable<GameObject>;
        var Enemy = EnemyBlackboardVariable != null ? EnemyBlackboardVariable.Value : default(GameObject);

        Event?.Invoke(Enemy);
    }

    public override Delegate CreateEventHandler(BlackboardVariable[] vars, System.Action callback)
    {
        EnemyExitTheTriggerEventHandler del = (Enemy) =>
        {
            BlackboardVariable<GameObject> var0 = vars[0] as BlackboardVariable<GameObject>;
            if(var0 != null)
                var0.Value = Enemy;

            callback();
        };
        return del;
    }

    public override void RegisterListener(Delegate del)
    {
        Event += del as EnemyExitTheTriggerEventHandler;
    }

    public override void UnregisterListener(Delegate del)
    {
        Event -= del as EnemyExitTheTriggerEventHandler;
    }
}

