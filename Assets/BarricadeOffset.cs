using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarricadeOffset : MonoBehaviour
{
    private Transform barricadeModel;
    // Start is called before the first frame update
    void Start()
    {
        barricadeModel = transform.GetChild(0);
        barricadeModel.localRotation = Quaternion.Euler(barricadeModel.localEulerAngles.x, Random.Range(-12f, 12f), 0);
    }

    
}
