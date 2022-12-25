using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBrain : Holdable
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Transform barrel;
    [SerializeField]
    private Transform head;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //turn head to target for y axis, turn barrel to target for x axis
        head.LookAt(target);
        // barrel.LookAt(target);
        //make sure head doesn't rotate on x axis
        barrel.localEulerAngles = new Vector3(head.localEulerAngles.x + 180, 0, 0);
        head.localEulerAngles = new Vector3(0, head.localEulerAngles.y, 0);
        //make sure barrel doesn't rotate on y axis
    }
}
