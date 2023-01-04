using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretBrain : Holdable
{
    private Transform target;

    [SerializeField]
    private Transform bulletSpawnpoint;

    [SerializeField]
    private Transform barrel;
    [SerializeField]
    private Transform head;
    [SerializeField]
    private Slider bulletBar;
    [SerializeField]
    private Slider healthBar;

    [SerializeField]
    private GameObject bulletPrefab;
    private float closestDistace;
    private float shootTimer = 0;

    [SerializeField]
    private int maxTargets = 3;
    private List<EnemyBrain> targetEnemies = new List<EnemyBrain>();

    [Header("Turret Stats")]
    // turret Stats
    private int bulletCount = 10;
    private float bulletSpeed = 20f;
    private float bulletDamage = 2f;
    private float shootDelay = .1f;
    private float range = 10f;
    private float shootRange = 5f;
    private float health = 5f;

    public void turretSetup(TurretRecipe recipe) {
        bulletCount = recipe.bulletCount;
        bulletSpeed = recipe.bulletSpeed;
        bulletDamage = recipe.bulletDamage;
        shootDelay = recipe.shootDelay;
        range = recipe.range;
        shootRange = recipe.shootRange;
        health = recipe.health;
        
        bulletBar.maxValue = bulletCount;
        bulletBar.minValue = 0;
        healthBar.maxValue = health;
        healthBar.minValue = 0;
    }

    private void Start() {
        
        bulletBar.maxValue = bulletCount;
        bulletBar.minValue = 0;
        healthBar.maxValue = health;
        healthBar.minValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //turn head to target for y axis, turn barrel to target for x axis
        if (target != null) {
            head.LookAt(target);
        }
        // barrel.LookAt(target);
        //make sure head doesn't rotate on x axis
        barrel.localEulerAngles = new Vector3(head.localEulerAngles.x + 180, 0, 0);
        head.localEulerAngles = new Vector3(0, head.localEulerAngles.y, 0);
        //make sure barrel doesn't rotate on y axis

        //get all colliders in range
        Collider[] colliders = Physics.OverlapSphere(transform.position, range);
        //find the closest collider
        float closestDistance = Mathf.Infinity;
        foreach (Collider collider in colliders) {
            if (collider.tag == "Enemy") {
                float distance = Vector3.Distance(transform.position, collider.transform.position);
                if (distance < closestDistance) {
                    closestDistance = distance;
                    target = collider.GetComponentInParent<EnemyBrain>().transform.GetChild(0);
                }
            }
        }

        if (target) {
            if (Vector3.Distance(target.position, transform.position) < shootRange) {
                shootTarget(target);
            }
            shootTimer -= Time.deltaTime;
        }

        bulletBar.value = bulletCount;
        healthBar.value = health;

        //check targetEnemies for dead enemies
        for (int i = 0; i < targetEnemies.Count; i++) {
            if (targetEnemies[i] == null) {
                targetEnemies.RemoveAt(i);
            }
        }
        
    }

    public void takeDamage(float damage) {
        health -= damage;
        if (health <= 0) {
            Destroy(gameObject);
        }
    }

    private void shootTarget(Transform target) {
        if (shootTimer <= 0 && bulletCount > 0) {
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnpoint.position, bulletSpawnpoint.rotation);
            bullet.GetComponent<bulletBrain>().speed = bulletSpeed;
            bullet.GetComponent<bulletBrain>().damage = bulletDamage;
            shootTimer = shootDelay;
            bulletCount--;
        }
    }

    public bool setTarget(EnemyBrain enemy) {
        if (targetEnemies.Count < maxTargets) {
            targetEnemies.Add(enemy);
            return true;
        }
        return false;
    }
}
