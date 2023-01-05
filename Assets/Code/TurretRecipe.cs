using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AssembleRecipe", menuName = "OverTurret/Turret Recipe", order = 0)]
public class TurretRecipe : AssembleRecipe
{
    public int bulletCount = 20;
    public float bulletDamage = 2f;
    public float bulletSpeed = 20f;
    public float shootDelay = .5f;
    public float range = 10f;
    public float shootRange = 5f;
    public float health = 5f;
    public float lifeDeduction = .3f;
    public float explosionRange = 3f;
    public float explosionDamage = 3f;
    public float assembleTime = 2f;

}
