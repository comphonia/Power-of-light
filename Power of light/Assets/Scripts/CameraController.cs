using System;
using UnityEngine;

public class CameraController : MonoBehaviour {
    [SerializeField] float leftBorderX;
    [SerializeField] float rightBorderX;
    [SerializeField] float bottomBorderZ;
    [SerializeField] float topBorderZ; 

    [SerializeField] float maxZoom = 25;
    [SerializeField] float minZoom = 50;
    [SerializeField] float dragSpeed = 2;

    bool dragging = false;
    Vector3 oldPosition;
    Vector3 panOriginPos; 
    bool reverse = false; 

    new Camera camera;

    private void Awake()
    {
        camera = GetComponent<Camera>();
        if (leftBorderX > rightBorderX)
        {
            reverse = true;
            float swap = rightBorderX;
            rightBorderX = leftBorderX;
            leftBorderX = swap; 
        }
        if (bottomBorderZ > topBorderZ)
        {
            reverse = true;
            float swap = bottomBorderZ;
            bottomBorderZ = topBorderZ;
            topBorderZ = swap; 
        }
    }

    // Update is called once per frame
    void Update () {
        MoveCamera();
        DragCamera(); 
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

        float direction = 1;
        if (reverse) direction = -1;

        float xDirection = direction*Input.GetAxis("Horizontal");
        float zDirection = direction*Input.GetAxis("Vertical");
        transform.Translate(new Vector3(xDirection, 0, zDirection),Space.World ); 
    }
    
    private void DragCamera()
    {
        if (Input.GetMouseButtonDown(2))
        {
            dragging = true;
            oldPosition = transform.position;
            panOriginPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);                    
        }

        if (Input.GetMouseButton(2))
        {
            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition) - panOriginPos;    
            float xDiff = pos.x;
            float zDiff = pos.y;
            pos = new Vector3(xDiff, 0, zDiff); 
            transform.position = oldPosition + pos * dragSpeed;                                         
        }

        if (Input.GetMouseButtonUp(2))
        {
            dragging = false;
        }
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
