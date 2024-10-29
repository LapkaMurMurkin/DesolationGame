using System;
using Unity.Behavior.GraphFramework;
using Unity.Behavior;
using UnityEngine;
using Unity.Properties;

#if UNITY_EDITOR
[CreateAssetMenu(menuName = "Behavior/Event Channels/EnemyEnterInTrigger")]
#endif
[Serializable, GeneratePropertyBag]
[EventChannelDescription(name: "EnemyEnterInTrigger", message: "Agent has spotted [Enemy]", category: "Events", id: "ae9e7be6c2ddb9b9c931448a4301ecd2")]
public partial class EnemyEnterInTrigger : EventChannelBase
{
    public delegate void EnemyEnterInTriggerEventHandler(Transform Enemy);
    public event EnemyEnterInTriggerEventHandler Event; 

    public void SendEventMessage(Transform Enemy)
    {
        Event?.Invoke(Enemy);
    }

    public override void SendEventMessage(BlackboardVariable[] messageData)
    {
        BlackboardVariable<Transform> EnemyBlackboardVariable = messageData[0] as BlackboardVariable<Transform>;
        var Enemy = EnemyBlackboardVariable != null ? EnemyBlackboardVariable.Value : default(Transform);

        Event?.Invoke(Enemy);
    }

    public override Delegate CreateEventHandler(BlackboardVariable[] vars, System.Action callback)
    {
        EnemyEnterInTriggerEventHandler del = (Enemy) =>
        {
            BlackboardVariable<Transform> var0 = vars[0] as BlackboardVariable<Transform>;
            if(var0 != null)
                var0.Value = Enemy;

            callback();
        };
        return del;
    }

    public override void RegisterListener(Delegate del)
    {
        Event += del as EnemyEnterInTriggerEventHandler;
    }

    public override void UnregisterListener(Delegate del)
    {
        Event -= del as EnemyEnterInTriggerEventHandler;
    }
}

