using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject monsterPrefab;
    public float spawnDelay = 3;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating( "SpawnNext", spawnDelay, spawnDelay );
    }

    void SpawnNext()
    {
        Instantiate( monsterPrefab, transform.position, Quaternion.identity );
    }
}
