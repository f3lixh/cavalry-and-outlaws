using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlawSpawner : MonoBehaviour
{
    public Transform outlaw;
    public Transform spawnPoint;

    public float waveDelay = 0.1f;
    float[] outlawsPerWave = { 4, 10 , 15, 22, 35, 48 };

    public static float currentWave = 0f;
    public static float outlawsAlive = 0f;
    public static float maxWave = 0f;
    public static bool isWon = false;

    float countdown = 0.1f;


	void Update()
	{

        if( isWon ) return;
        outlawsAlive = FindObjectsOfType<Outlaw>().Length;
        maxWave = outlawsPerWave.Length;

        if( countdown <= 0f && outlawsAlive == 0 && currentWave < maxWave )
        {
            StartCoroutine( SpawnWave() );
            countdown = waveDelay;
            

        }
        else if( currentWave == maxWave && outlawsAlive == 0) 
        {
           
            isWon = true;
		}

        countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave()
    {
          
        for( int i = 0; i < outlawsPerWave[(int)currentWave]; i++ )
        {
           
            Instantiate( outlaw, spawnPoint.position, spawnPoint.rotation );
            
            yield return new WaitForSeconds( 1f );
        }
        currentWave++;
    }

 
}
