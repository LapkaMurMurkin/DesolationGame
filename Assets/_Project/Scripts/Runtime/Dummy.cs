using UnityEngine;

public class Dummy : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerWeaponCollider>() is PlayerWeaponCollider)
            Debug.Log("Dummy Hit!");
    }
}
