using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBrain : Holdable
{
    private Transform target;

    [SerializeField]
    private float range = 10f;
    [SerializeField]
    private float shootRange = 5f;
    [SerializeField]
    private float shootDelay = .1f;
    [SerializeField]
    private Transform bulletSpawnpoint;
    [SerializeField]
    private float bulletSpeed = 20f;
    private float shootTimer = 0;

    [SerializeField]
    private Transform barrel;
    [SerializeField]
    private Transform head;
    [SerializeField]
    private GameObject bulletPrefab;
    private float closestDistace;
    // Start is called before the first frame update
    void Start()
    {
        
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


    }

    private void shootTarget(Transform target) {
        if (shootTimer <= 0) {
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnpoint.position, bulletSpawnpoint.rotation);
            bullet.GetComponent<bulletBrain>().speed = bulletSpeed;
            shootTimer = shootDelay;
        }
    }
}
