using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssemblerBrain : TableBrain
{

    public GameObject[] itemsOnTable;
    [SerializeField]
    public int maxItemsOnTable = 3;
    public int itemsOnTableCount = 0;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        itemsOnTable = new GameObject[maxItemsOnTable];
    }

    // Update is called once per frame
    public override void Update()
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

    public void Assemble()
    {
        //get names of all items on the table
        string[] itemNames = new string[itemsOnTableCount];
        for (int i = 0; i < itemsOnTableCount; i++) {
            itemNames[i] = itemsOnTable[i].GetComponent<MaterialBrain>().materialName;
        }

        //check if there is a recipe that matches the items on the table, order doesn't matter
        AssembleRecipe recipe = null;
        foreach (AssembleRecipe r in AssembleManager.recipes) {
            if (r.checkRecipe(itemNames)) {
                recipe = r;
                break;
            }
        }

        //if there is a recipe, remove all items from the table and spawn the product
        if (recipe != null) {
            //destroy all items on the table
            for (int i = 0; i < itemsOnTableCount; i++) {
                Destroy(itemsOnTable[i]);
            }
            itemsOnTableCount = 0;
            itemsOnTable = new GameObject[maxItemsOnTable];

            GameObject product = Instantiate(recipe.product, itemAnchor.position, itemAnchor.rotation);
            PlaceItemOnTable(product);
        } else  {
            Debug.Log("No recipe found");
        }
    }
}
