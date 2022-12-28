using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyBrain : MonoBehaviour
{
    [SerializeField]
    private Slider healthBar;
    private NavMeshAgent agent;
    private Transform player;
    public float health = 10f;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        healthBar.maxValue = health;
        healthBar.minValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.position);
        healthBar.value = health;
        if (health <= 0) {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float damage) {
        health -= damage;
    }
}
