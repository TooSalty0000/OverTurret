using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableBrain : MonoBehaviour
{

    public Transform itemAnchor;
    public GameObject itemOnTable;
    public bool itemPlaced;
    // Start is called before the first frame update
    public virtual void Start()
    {
        itemAnchor = transform.GetChild(0);
    }

    // Update is called once per frame
    public virtual void Update()
    {
        itemPlaced = itemOnTable != null;

        if (itemOnTable != null) {
            itemOnTable.transform.position = itemAnchor.position;
            itemOnTable.transform.rotation = itemAnchor.rotation;
        }
    }


    public virtual bool PlaceItemOnTable (GameObject holdable) {
        if (itemOnTable == null) {
            itemOnTable = holdable;
            holdable.transform.position = itemAnchor.position;
            holdable.transform.rotation = itemAnchor.rotation;
            return true;
        }
        return false;
    }

    public virtual GameObject RemoveItemFromTable () {
        GameObject item = itemOnTable;
        itemOnTable = null;
        return item;
    }
}
