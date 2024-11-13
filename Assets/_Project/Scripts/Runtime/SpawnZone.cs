using System.Collections.Generic;
using Unity.Behavior;
using UnityEngine;

public class SpawnZone : MonoBehaviour
{
    public GameObject Prefab;
    public List<GameObject> SpawnedObjects;
    public int MaxCount { get; private set; }
    public int CurrentCount { get; private set; }
    private float _colliderRadius;

    public void Awake()
    {
        MaxCount = 5;
        CurrentCount = SpawnedObjects.Count;
        _colliderRadius = Prefab.GetComponent<CapsuleCollider>().radius;
    }

    private void Update()
    {
        SpawnedObjects.RemoveAll(x => x == null);
        CurrentCount = SpawnedObjects.Count;

        if (CurrentCount < MaxCount)
        {
            SpawnPrefab();
        }
    }

    private void SpawnPrefab()
    {
        Vector3 position = transform.position + Random.onUnitSphere * transform.localScale.x;
        position.y = 0;
        Quaternion rotation = new Quaternion();
        rotation.SetLookRotation(Vector3.left);

        GameObject prefab = Instantiate(Prefab, position, rotation);
        prefab.GetComponent<Enemy>().Initialize(transform);
        SpawnedObjects.Add(prefab);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.25f);
        Gizmos.DrawSphere(transform.position, transform.lossyScale.x);
    }
}
