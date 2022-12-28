using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletBrain : MonoBehaviour
{
    public float speed = 10f;
    public float damage = 1;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Enemy") {
            other.GetComponentInParent<EnemyBrain>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
