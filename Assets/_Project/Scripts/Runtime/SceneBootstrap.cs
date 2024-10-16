using UnityEngine;

public class SceneBootstrap : MonoBehaviour
{
    public static ServiceLocator ServiceLocator = new ServiceLocator();

    private ActionMap _actionMap;

    private Player _player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        ServiceLocator = new ServiceLocator();

        _actionMap = new ActionMap();
        _actionMap.Enable();
        ServiceLocator.Register<ActionMap>(_actionMap);

        _player = FindFirstObjectByType<Player>();
        _player.Initialize();
        ServiceLocator.Register<Player>(_player);
    }
}
