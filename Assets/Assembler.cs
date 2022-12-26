using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assembler : TableBrain
{

    public GameObject[] itemsOnTable;
    [SerializeField]
    private int maxItemsOnTable = 3;
    private int itemsOnTableCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        itemAnchor = transform.GetChild(0);
        itemsOnTable = new GameObject[maxItemsOnTable];
    }

    // Update is called once per frame
    void Update()
    {
        itemPlaced = itemsOnTableCount > 0;
    }

    public override bool PlaceItemOnTable(GameObject holdable)
    {
        if (itemsOnTableCount < maxItemsOnTable) {
            itemsOnTable[itemsOnTableCount] = holdable;
            itemsOnTableCount++;
            holdable.transform.position = itemAnchor.position;
            holdable.transform.rotation = itemAnchor.rotation;
            //disable all mesh renderers in the holdable
            MeshRenderer[] meshRenderers = holdable.GetComponentsInChildren<MeshRenderer>();
            foreach (MeshRenderer meshRenderer in meshRenderers) {
                meshRenderer.enabled = false;
            }
            return true;
        }
        return false;
        
    }

    public override GameObject RemoveItemFromTable()
    {
        GameObject itemFromTable = itemsOnTable[itemsOnTableCount - 1];
        itemsOnTable[itemsOnTableCount - 1] = null;
        itemsOnTableCount--;
        //enable all mesh renderers in the objectFromTable
        MeshRenderer[] meshRenderers = itemFromTable.GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer meshRenderer in meshRenderers) {
            meshRenderer.enabled = true;
        }
        return itemFromTable;
    }
}
