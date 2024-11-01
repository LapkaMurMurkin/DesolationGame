using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private List<SpawnZone> _zones;
    [SerializeField]
    private Color _color;

/*     private void OnDrawGizmos()
    {
        Gizmos.color = _color;

        foreach (SpawnZone zone in _zones)
        {
            Gizmos.DrawSphere(zone.transform.position, zone.transform.lossyScale.x);
        }
    } */

/*     private void Start()
    {
        foreach (SpawnZone zone in _zones)
        {
            zone.SpawnPrefab();
        }
    } */

    private void Update()
    {

    }
}
