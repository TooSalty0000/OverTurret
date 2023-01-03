using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyData
{
    public GameObject enemyPrefab;
    [Range(0.1f, 10f)]
    public float spawnTime = 4f;
}
