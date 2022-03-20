using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    Camera cam;
    float sizeInSun = 11;
    float sizeInShade = 10;
    public float zoomSpeed = 0.08f;

    void Start()
    {
        SunManager.OnPlayerHit += changeCameraZoom;
        cam = Camera.main;
    }

    private void OnDestroy()
    {
        SunManager.OnPlayerHit -= changeCameraZoom;
    }

    public void changeCameraZoom(bool isHit)
    {
        if (isHit && cam.orthographicSize != sizeInSun)
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, sizeInSun, zoomSpeed);
        }
        else if(!isHit && cam.orthographicSize != sizeInShade )
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, sizeInShade, zoomSpeed); 
        }
    }
}
