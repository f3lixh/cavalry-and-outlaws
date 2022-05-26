using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New MonsterSpawnData", menuName = "Create MonsterSpawnData" )]
public class MonsterSpawnData : ScriptableObject
{
    public GameObject Monster;
    public int MonsterID;
}
