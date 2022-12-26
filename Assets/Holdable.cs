using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holdable : MonoBehaviour
{
    public virtual void OnPickup() {
        //disable all colliders if there are any
        Collider[] colliders = GetComponents<Collider>();
        foreach (Collider collider in colliders) {
            collider.enabled = false;
        }
        GetComponent<Rigidbody>().isKinematic = false;
    }

    public virtual void OnDrop() {
        //enable all colliders
        Collider[] colliders = GetComponents<Collider>();
        foreach (Collider collider in colliders) {
            collider.enabled = true;
        }
        GetComponent<Rigidbody>().isKinematic = false;
    }

    

}
