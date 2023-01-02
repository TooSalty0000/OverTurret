using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour
{
    [SerializeField]
    private Transform[] cameras;
    [SerializeField]
    private RenderTexture[] cameraRenderTextures;
    [SerializeField]
    private RawImage[] cameraDisplays;
    private int currentCameraIndex = 0;
    private Transform mainCamera;


    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main.transform;

        if (cameraDisplays.Length != cameras.Length - 1)
        {
            Debug.LogError("Camera displays and cameras don't match");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // when press tab, switch to next camera
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            currentCameraIndex++;
            if (currentCameraIndex >= cameras.Length)
            {
                currentCameraIndex = 0;
            }
            mainCamera.position = cameras[currentCameraIndex].position;
            mainCamera.rotation = cameras[currentCameraIndex].rotation;

            // change the camera display to the remaining cameras (this is for when there's multiple displays)
            int camDisplayCount = 0;
            for (int i = 0; i < cameraRenderTextures.Length; i++)
            {
                if (i != currentCameraIndex)
                {
                    cameraDisplays[camDisplayCount].texture = cameraRenderTextures[i];
                    camDisplayCount++;
                }
            }
        }

        // make the current camera to follow the main camera
        cameras[currentCameraIndex].position = mainCamera.position;
    }
}
