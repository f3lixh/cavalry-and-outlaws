using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlawSpawner : MonoBehaviour
{
    public Transform outlaw;
    public Transform spawnPoint;

    public float waveDelay = 5f;
    float countdown = 2f;

    int currentWave = 0;

    // Update is called once per frame
    void Update()
    {
        if(countdown <= 0f) {
            StartCoroutine( SpawnWave() );
            countdown = waveDelay;

        }
        countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave () {
        currentWave++;
        for( int i = 0; i < currentWave; i++ )
		{
            SpawnOutlaw();
            yield return new WaitForSeconds( 1f );
		}
       
	}

    void SpawnOutlaw()
    {
        Instantiate( outlaw, spawnPoint.position, spawnPoint.rotation );
    }
}
