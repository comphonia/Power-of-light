using System;
using UnityEngine;

public class CameraController : MonoBehaviour {
    [SerializeField] float leftBorderX;
    [SerializeField] float rightBorderX;
    [SerializeField] float bottomBorderZ;
    [SerializeField] float topBorderZ; 

    [SerializeField] float maxZoom = 25;
    [SerializeField] float minZoom = 50;

    new Camera camera;

    private void Awake()
    {
        camera = GetComponent<Camera>(); 
    }

    // Update is called once per frame
    void Update () {
        MoveCamera();
        ZoomCamera(); 
    }

    private void MoveCamera()
    { 
        float xPos = transform.position.x;
        float zPos = transform.position.z;

        if (xPos < leftBorderX)
        {
            xPos = leftBorderX;
        }
        else if (xPos > rightBorderX) xPos = rightBorderX;

        if (zPos < bottomBorderZ) zPos = bottomBorderZ;
        else if (zPos > topBorderZ) zPos = topBorderZ; 

        transform.position = new Vector3(xPos, transform.position.y, zPos);

        float xDirection = Input.GetAxis("Horizontal");
        float zDirection = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(xDirection, 0, zDirection),Space.World ); 
    }

    void ZoomCamera()
    {
        if (PlacementController.building == false) {
            if (camera.fieldOfView < maxZoom) camera.fieldOfView = maxZoom;
            else if (camera.fieldOfView > minZoom) camera.fieldOfView = minZoom;

            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                camera.fieldOfView--;
                //transform.position += new Vector3(0, .6f, .2f);
            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                camera.fieldOfView++;
                //transform.position -= new Vector3(0, .6f, .2f);
            }
        }
    }
}
