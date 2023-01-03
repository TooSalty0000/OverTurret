using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    private EnemyData[] enemyData;

    [SerializeField]
    private Transform[] spawnPoints;
    [SerializeField]
    private Transform target;

    private float[] spawnTimers;

    // Start is called before the first frame update
    void Start()
    {
        spawnTimers = new float[enemyData.Length];
        
        for (int i = 0; i < spawnTimers.Length; i++)
        {
            spawnTimers[i] = enemyData[i].spawnTime;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Loop through each spawn timer
        for (int i = 0; i < spawnTimers.Length; i++)
        {
            // If the timer is less than or equal to 0
            if (spawnTimers[i] <= 0)
            {
                // Spawn the enemy
                SpawnEnemy(i);
                // Reset the timer
                spawnTimers[i] = enemyData[i].spawnTime;
            }
            // Otherwise, subtract the time since the last frame from the timer
            else
            {
                spawnTimers[i] -= Time.deltaTime;
            }
        }
    }

    private void SpawnEnemy(int index)
    {
        // Get a random spawn point
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        // Spawn the enemy at the spawn point
        GameObject enemy = Instantiate(enemyData[index].enemyPrefab, spawnPoints[spawnPointIndex].position, Quaternion.identity);
        // Get the enemy's brain
        EnemyBrain brain = enemy.GetComponent<EnemyBrain>();
        // Set the enemy's target
        brain.SetTarget(target);
        
    }
}
