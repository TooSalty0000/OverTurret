using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "AssembleRecipe", menuName = "OverTurret/Assemble Recipe", order = 0)]
public class AssembleRecipe : ScriptableObject
{
    public string[] materials;
    public GameObject product;

    public bool checkRecipe (string[] itemNames) {
        if (itemNames.Length != materials.Length) {
            return false;
        }
        for (int i = 0; i < materials.Length; i++) {
            if (!itemNames.Contains(materials[i])) {
                return false;
            }
        }
        return true;
    }
}
