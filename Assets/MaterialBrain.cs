using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialBrain : Holdable
{
    private Transform model;
    private float rotateSpeed = 4f;
    private float hoverSpeed = 2f;
    private float yOffset = 0f;

    private bool isDropped = true;

    // Start is called before the first frame update
    void Start()
    {
        model = transform.GetChild(0);
        isDropped = true;
        yOffset = model.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        // hover and rotate the model by the given speed
        if (isDropped) {
            model.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
            model.localPosition = new Vector3(0, Mathf.Sin(Time.time * hoverSpeed) * 0.1f + 0.5f, 0);
        } else  {
            model.localRotation = Quaternion.identity;
            model.localPosition = new Vector3(0, yOffset, 0);
        }
    }

    //stop rotating and hovering when picked up and reset rotation
    public override void OnPickup() {
        base.OnPickup();
        isDropped = false;
    }

    //start rotating and hovering when dropped
    public override void OnDrop() {
        base.OnDrop();
        isDropped = true;
    }
}
