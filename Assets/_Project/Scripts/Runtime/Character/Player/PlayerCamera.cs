using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    private Camera _camera;
    private Vector3 _positionOffset;
    private float _smoothDamp;

    private Transform _playerTransform;

    private Vector3 _currentVelocity;
    //private int _height;


    public void Initialize(Player player)
    {
        _camera = GetComponent<Camera>();
        _positionOffset = new Vector3(0, 10, -5);
        _smoothDamp = 0.25f;

        _playerTransform = player.transform;

        _currentVelocity = Vector3.zero;
    }

    private void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, _playerTransform.position + _positionOffset, ref _currentVelocity, _smoothDamp);
        //transform.rotation.SetLookRotation(_playerTransform.position + Vector3.up);
        transform.LookAt(_playerTransform);
    }
}
