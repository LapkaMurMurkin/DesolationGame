using UnityEngine;

public class SceneBootstrap : MonoBehaviour
{
    public static ServiceLocator ServiceLocator = new ServiceLocator();

    private ActionMap _actionMap;

    private Player _player;
    private PlayerCamera _playerCamera;
    private Raycaster _raycaster;
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

        _playerCamera = FindFirstObjectByType<PlayerCamera>();
        _playerCamera.Initialize(_player);
        ServiceLocator.Register<PlayerCamera>(_playerCamera);

        _raycaster = new Raycaster(_playerCamera.GetComponent<Camera>());
        ServiceLocator.Register<Raycaster>(_raycaster);


    }
}
