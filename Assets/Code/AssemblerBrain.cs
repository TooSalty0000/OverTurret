using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssemblerBrain : TableBrain
{

    public GameObject[] itemsOnTable;
    [SerializeField]
    public int maxItemsOnTable = 3;
    public int itemsOnTableCount = 0;
    [SerializeField]
    private Slider assembleBar;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        itemsOnTable = new GameObject[maxItemsOnTable];
        assembleBar.gameObject.SetActive(false);
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
        if (itemsOnTableCount < 3) {
            Debug.Log("Not enough items on table");
            return;
        }
        string[] itemNames = new string[itemsOnTableCount];
        for (int i = 0; i < itemsOnTableCount; i++) {
            itemNames[i] = itemsOnTable[i].GetComponent<MaterialBrain>().materialName;
        }

        //check if there is a recipe that matches the items on the table, order doesn't matter
        TurretRecipe recipe = null;
        foreach (TurretRecipe r in AssembleManager.turretRecipes) {
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

            StartCoroutine(AssembleCoroutine(recipe));

        } else  {
            Debug.Log("No recipe found");
        }
    }

    public IEnumerator AssembleCoroutine(TurretRecipe recipe)
    {
        assembleBar.gameObject.SetActive(true);
        assembleBar.maxValue = recipe.assembleTime;
        assembleBar.value = 0;
        float createTimer = 0f;
        while (createTimer < recipe.assembleTime) {
            createTimer += Time.deltaTime;
            assembleBar.value = createTimer;
            yield return null;
        }

        GameObject product = Instantiate(recipe.product, itemAnchor.position, itemAnchor.rotation);
        TurretBrain turretBrain = product.GetComponent<TurretBrain>();
        turretBrain.turretSetup(recipe);

        PlaceItemOnTable(product);

        assembleBar.gameObject.SetActive(false);
        StopAllCoroutines();
    }
}
