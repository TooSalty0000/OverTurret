using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holdable : MonoBehaviour
{
    public virtual void OnPickup() {
        //disable all colliders in self if there are any
        Collider[] colliders = GetComponents<Collider>();
        foreach (Collider collider in colliders) {
            collider.enabled = false;
        }
        //disable all colliders in children if there are any
        colliders = GetComponentsInChildren<Collider>();
        foreach (Collider collider in colliders) {
            collider.enabled = false;
        }

        GetComponent<Rigidbody>().isKinematic = false;
    }

    public virtual void OnDrop() {
        //enable all colliders in self
        Collider[] colliders = GetComponents<Collider>();
        foreach (Collider collider in colliders) {
            collider.enabled = true;
        }
        //enable all colliders in children
        colliders = GetComponentsInChildren<Collider>();
        foreach (Collider collider in colliders) {
            collider.enabled = true;
        }

        GetComponent<Rigidbody>().isKinematic = false;
    }

    

}
