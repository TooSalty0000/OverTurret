using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyBrain : MonoBehaviour
{
    [SerializeField]
    private Slider healthBar;
    private float detectRange = 10f;
    private float attackRange = 1.5f;
    private NavMeshAgent agent;
    private Transform target;
    private Transform beacon;
    public float health = 10f;
    private float damage = 1f;
    private float attackDelay = 2f;
    private float speed = 1f;
    private Animator animator;
    private float attackTimer = 0f;
    private bool haveAnimated = false;
    // Start is called before the first frame update

    public void setStats (EnemyData data) {
        health = data.maxHealth;
        damage = data.damage;
        attackDelay = data.attackDelay;
        detectRange = data.detectRange;
        speed = data.speed;
    }
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        healthBar.maxValue = health;
        healthBar.minValue = 0;
        animator = GetComponent<Animator>();
        attackTimer = attackDelay - 1f;
    }

    // Update is called once per frame
    void Update()
    {
        

        // detect turrets in range and sort by distance from closest to furthest
        if (target == null) {
            agent.isStopped = false;
            agent.SetDestination(beacon.position);
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectRange);
            List<Transform> turrets = new List<Transform>();
            foreach (Collider collider in hitColliders) {
                if (collider.GetComponentInParent<TurretBrain>()) {
                    turrets.Add(collider.transform);
                }
            }
            turrets.Sort((a, b) => Vector3.Distance(transform.position, a.position).CompareTo(Vector3.Distance(transform.position, b.position)));
            // from the closest turret, if it can be set as a target, set it as a target
            foreach (Transform turret in turrets) {
                if (turret.GetComponentInParent<TurretBrain>().setTarget(this)) {
                    target = turret;
                    break;
                }
            }
        } else {
            // if target is in range, stop moving and attack
            if (Vector3.Distance(transform.position, target.position) < attackRange) {
                agent.isStopped = true;
                attackTimer += Time.deltaTime;
                if (!haveAnimated && attackTimer >= attackDelay - 0.5f) {
                    animator.SetTrigger("Attack");
                    haveAnimated = true;
                }
                if (attackTimer >= attackDelay) {
                    attackTimer = 0f;
                    haveAnimated = false;
                    target.GetComponentInParent<TurretBrain>().takeDamage(damage);
                }
            } else {
                // if target is out of range, move towards it
                agent.isStopped = false;
                agent.SetDestination(target.position);
            }
        }

        healthBar.value = health;
        if (health <= 0) {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float damage) {
        health -= damage;
    }

    public void SetBeacon(Transform _beacon) {
        this.beacon = _beacon;
    }

}
