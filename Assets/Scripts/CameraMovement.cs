using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Camera mainCamera;
    private Bounds cameraBounds;
    private Vector3 targetPosition = new Vector3(0,0,-10);
    

    private void Awake()
    {
        mainCamera = Camera.main;
    }
    void Start()
    {
        float height = mainCamera.orthographicSize;
        float width = height * mainCamera.aspect;

        float minX = Globals.WorldBounds.min.x + width;
        float maxX = Globals.WorldBounds.extents.x - width;

        float minY = Globals.WorldBounds.min.y + height;
        float maxY = Globals.WorldBounds.extents.y - height;

        cameraBounds = new Bounds();
        cameraBounds.SetMinMax(
            new Vector3(minX, minY, 0), 
            new Vector3(maxX, maxY, 0)
            );

    }
    private Vector3 GetCameraBounds()
    {
        return new Vector3(
            Mathf.Clamp(targetPosition.x, cameraBounds.min.x, cameraBounds.max.x),
            Mathf.Clamp(targetPosition.y, cameraBounds.min.y, cameraBounds.max.y),
            transform.position.z
            );
    }

    private void LateUpdate()
    {
       // transform.position = targetPosition
    }
    void Update()
    {
        
    }
}
