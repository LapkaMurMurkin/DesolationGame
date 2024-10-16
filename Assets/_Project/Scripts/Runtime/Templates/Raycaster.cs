using UnityEngine;


public class Raycaster
{
    private Camera _playerCamera;
    private Ray _cursorRay;
    private RaycastHit _rayHitInformation;

    public Raycaster(Camera playerCamera)
    {
        _playerCamera = playerCamera;
    }

    public void InitializeCursorRay()
    {
        _cursorRay = _playerCamera.ScreenPointToRay(Input.mousePosition);
    }

    public bool CastRay(Vector3 startPoint, Vector3 direction)
    {
        return Physics.Raycast(startPoint, direction, out _rayHitInformation, 100);
    }

    /*     public bool CastCursorRay()
        {
            InitializeCursorRay();
            return Physics.Raycast(_cursorRay, out _rayHitInformation, 100);
        } */

    public Vector3 GetWorlPoint()
    {
        _cursorRay = _playerCamera.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(_cursorRay, out _rayHitInformation, 100);
        return _rayHitInformation.point;
    }

    public RaycastHit GetRayHitInformation()
    {
        return _rayHitInformation;
    }

    public GameObject GetGameObjectUnderCursor()
    {
        return _rayHitInformation.transform?.gameObject;
    }

    /*     public IInteractable GetInteractableUnderCursor()
        {
            InitializeCursorRay();
            CastCursorRay();
            GameObject gameObject = GetGameObjectUnderCursor();
            return gameObject?.GetComponent<IInteractable>();
        } */
}
