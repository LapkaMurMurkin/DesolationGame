using UnityEngine;

public class AgentStart : MonoBehaviour
{
    [SerializeField] private GameObject _agent;
    [SerializeField] private AgentInitEvent _initEvent;

    public void Init(Transform origin)
    {
        _initEvent.SendEventMessage(_agent, origin);
    }
}
