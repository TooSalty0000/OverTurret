using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private float cameraSpeed = 1.0f;

    [SerializeField]
    private Vector2 cameraBounds = new Vector2(0, 48);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // move camera with arrow keys
        Vector3 inputMovement = new Vector3(Input.GetAxisRaw("HorizontalArrow"), 0, 0);
        inputMovement.Normalize();
        transform.position += Time.deltaTime * new Vector3(inputMovement.x * cameraSpeed, 0, 0);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, cameraBounds.x, cameraBounds.y), transform.position.y, transform.position.z);
    }
}
