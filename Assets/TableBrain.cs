using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableBrain : MonoBehaviour
{

    private Transform itemAnchor;
    private GameObject itemOnTable;
    public bool itemPlaced;
    // Start is called before the first frame update
    void Start()
    {
        itemAnchor = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        itemPlaced = itemOnTable != null;
    }

    public bool PlaceItemOnTable (GameObject holdable) {
        if (itemOnTable == null) {
            itemOnTable = holdable;
            holdable.transform.position = itemAnchor.position;
            holdable.transform.rotation = itemAnchor.rotation;
            return true;
        }
        return false;
    }

    public GameObject RemoveItemFromTable () {
        GameObject item = itemOnTable;
        itemOnTable = null;
        return item;
    }
}
