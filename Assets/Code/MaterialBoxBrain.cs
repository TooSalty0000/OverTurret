using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialBoxBrain : TableBrain
{
    [SerializeField]
    private GameObject material;

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        // if there is no item on the table, spawn a new one
        if (itemOnTable == null) {
            GameObject newMaterial = Instantiate(material, itemAnchor.position, itemAnchor.rotation);
            PlaceItemOnTable(newMaterial);
            newMaterial.GetComponent<MaterialBrain>().OnPickup();
            newMaterial.GetComponent<MaterialBrain>().tablePlacedOn = this;
        }
    }
}
