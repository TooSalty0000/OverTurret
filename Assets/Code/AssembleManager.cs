using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssembleManager : MonoBehaviour
{
    public static AssembleManager instance;

    public static TurretRecipe[] turretRecipes;

    private void Awake() {
        turretRecipes = Resources.LoadAll<TurretRecipe>("Turret Recipes");
        if (instance == null) {
            instance = this;
        } else {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
