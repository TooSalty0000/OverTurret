using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialBoxBrain : TableBrain
{
    [SerializeField]
    private GameObject material;
    [SerializeField]
    private Material hologramMaterial;
    private Animator animator;

    public override void Start()
    {
        animator = GetComponent<Animator>();
        GameObject hologram = Instantiate(material, itemAnchor.position, itemAnchor.rotation);
        hologram.transform.parent = itemAnchor;
        Destroy(hologram.GetComponent<MaterialBrain>());
        Destroy(hologram.GetComponent<Rigidbody>());
        Destroy(hologram.GetComponent<Collider>());
        hologram.transform.tag = "Hologram";
        MeshRenderer[] renderers = hologram.GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer renderer in renderers) {
            renderer.material = hologramMaterial;
        }
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        itemPlaced = true;
    }

    public override bool PlaceItemOnTable(GameObject holdable)
    {
        return false;
    }

    public override GameObject RemoveItemFromTable()
    {
        animator.SetTrigger("Open");
        return Instantiate(material, itemAnchor.position, itemAnchor.rotation);
    }
}
