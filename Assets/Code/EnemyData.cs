using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class EnemyData : ScriptableObject
{
    public string enemyName;
    public GameObject enemyPrefab;
    public float spawnTime = 4f;
    public float maxHealth = 10;
    public float speed = 1f;
    public float damage = 1f;
    public float attackDelay = 2f;
    public float detectRange = 5f;
    public float attackRange = 1.5f;


}
