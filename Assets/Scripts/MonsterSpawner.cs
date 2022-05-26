using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public static List<Monster> MonstersAlive;
    public static Dictionary<int, GameObject> Monsters;
    public static Dictionary<int, Queue<Monster>> MonsterPool;
    void Start()
    {
        Monsters = new Dictionary<int, GameObject>();
        MonsterPool = new Dictionary<int, Queue<Monster>>();
        MonstersAlive = new List<Monster>();

        MonsterSpawnData[] MonsterArray = Resources.LoadAll<MonsterSpawnData>( "Monster" );
        Debug.Log( MonsterArray[0].name );

        foreach (MonsterSpawnData monster in MonsterArray )
        {
            Monsters.Add( monster.MonsterID, monster.Monster );
            MonsterPool.Add( monster.MonsterID, new Queue<Monster>( ));

        }
    }

    public static Monster SpawnMonster(int MonesterID) {
        Monster SpawnedMonester = null;




        return SpawnedMonester;
	}


}
