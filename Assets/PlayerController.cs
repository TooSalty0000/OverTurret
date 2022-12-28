using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]
    private float speed = 2.0f;
    [SerializeField]
    private float throwPower = 10.0f;

    [SerializeField]
    private Transform HandPosition;
    [SerializeField]
    private Slider throwPowerSlider;


    [SerializeField] 
    private GameObject HoldingObject;


    
    public GameObject closestHoldable;
    public float closestHoldableDistance;


    public GameObject closestTable;
    public float closestTableDistance;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update() 
    {
        //movement
        Vector3 inputMovement = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        inputMovement.Normalize();
        rb.velocity = new Vector3(inputMovement.x * speed, rb.velocity.y, inputMovement.z * speed);

        //look according to inputMovement (diagnal movement included)
        if (inputMovement != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(inputMovement);
        }

        //turret management
        // disable turret rigidbody if holding it
        if (HoldingObject != null) {
            HoldingObject.GetComponent<Rigidbody>().isKinematic = true;
            HoldingObject.transform.position = HandPosition.position;
            HoldingObject.transform.rotation = HandPosition.rotation;
        }

        // check for all objects with tag "Holdable" in range of 5 units and set closestHoldable to the closest one
        if (HoldingObject == null) {
            GameObject[] holdables = GameObject.FindGameObjectsWithTag("Holdable");
            closestHoldable = null;
            closestHoldableDistance = 2f;
            foreach (GameObject holdable in holdables) {
                float distance = Vector3.Distance(transform.position + transform.forward * 0.2f, holdable.transform.position);
                if (distance < closestHoldableDistance) {
                    closestHoldable = holdable;
                    closestHoldableDistance = distance;
                }
            }
        }

        // if space is pressed
        if (Input.GetKeyDown(KeyCode.Space)) {
            // if there's a table and we're holding an object, place it on the table
            if (closestTable != null && HoldingObject != null) {
                TableBrain _table = closestTable.GetComponent<TableBrain>();
                if (_table.PlaceItemOnTable(HoldingObject) ) {
                    HoldingObject = null;
                }
            // if there's a table and we're not holding an object and there's item on the table, remove an object from the table
            } else if (closestTable != null && HoldingObject == null && closestTable.GetComponent<TableBrain>().itemPlaced) {
                TableBrain _table = closestTable.GetComponent<TableBrain>();
                GameObject item = _table.RemoveItemFromTable();
                if (item != null) {
                    HoldingObject = item;
                    HoldingObject.GetComponent<Holdable>().OnPickup();
                }
            } else if (HoldingObject == null && closestHoldable != null) {
                HoldingObject = closestHoldable;
                HoldingObject.GetComponent<Holdable>().OnPickup();
            } else if (HoldingObject != null) {
                HoldingObject.GetComponent<Rigidbody>().isKinematic = false;
                Vector3 forceDirection = transform.forward * throwPower;
                HoldingObject.GetComponent<Rigidbody>().AddForce(forceDirection, ForceMode.Impulse);
                HoldingObject.transform.parent = null;
                HoldingObject.GetComponent<Holdable>().OnDrop();
                HoldingObject = null;
            }
        }

        // constantly check for all objects with tag "Table" in range of 1 unit and set closestTable to the closest one
        GameObject[] tables = GameObject.FindGameObjectsWithTag("Table");
        closestTable = null;
        closestTableDistance = 1f;
        foreach (GameObject table in tables) {
            float distance = Vector3.Distance(transform.position + transform.forward * 0.3f, table.transform.position);
            if (distance < closestTableDistance) {
                closestTable = table;
                closestTableDistance = distance;
            }
        }

        // when press f, check if the cloest table is an assembler, if so, assemble
        if (Input.GetKeyDown(KeyCode.F)) {
            if (closestTable != null && closestTable.GetComponent<AssemblerBrain>()) {
                closestTable.GetComponent<AssemblerBrain>().Assemble();
            }
        }



    }
}
