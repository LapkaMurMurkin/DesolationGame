using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class SpawnZone : MonoBehaviour
{
    public GameObject Prefab;
    public List<GameObject> SpawnedObjects;
    public int MaxCount { get; private set; }
    public int CurrentCount { get; private set; }
    //private float _colliderRadius;

    public void Awake()
    {
        MaxCount = 1;
        CurrentCount = SpawnedObjects.Count;
    }

    private void Update()
    {
        SpawnedObjects.RemoveAll(x => x == null);
        CurrentCount = SpawnedObjects.Count;

        SpawnPrefab();
    }

    private void SpawnPrefab()
    {
        if (CurrentCount < MaxCount)
        {
            Vector3 position = transform.position + (Random.onUnitSphere * transform.lossyScale.x) / 2;
            position.y = 1;
            Quaternion rotation = new Quaternion();
            rotation.SetLookRotation(Vector3.left);

            GameObject spawnedPrefab = Instantiate(Prefab, position, rotation);
            SpawnedObjects.Add(spawnedPrefab);

            Enemy enemy = spawnedPrefab.GetComponent<Enemy>();
            enemy.Initialize(transform);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.25f);
        Gizmos.DrawSphere(transform.position, transform.lossyScale.x);
    }
}
