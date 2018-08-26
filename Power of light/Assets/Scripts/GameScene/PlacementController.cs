using System;
using UnityEngine;

public class PlacementController : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsPrefs;
    [SerializeField] LayerMask whereToPlace; 

    GameObject currentPlaceableObject;

    float mouseWheelRotation;
    int currentPrefabIndex = -1;

    private void Update()
    {
        if (currentPlaceableObject != null)
        {
            MoveCurrentObjectToMouse();
            //RotateFromMouseWheel();
            ReleaseIfClicked();
        }
    }

    public void HandleNewObject(int number)
    {
        if (PressedKeyOfCurrentPrefab(number))
        {
            Destroy(currentPlaceableObject);
            currentPrefabIndex = -1;
        }
        else
        {
            if (currentPlaceableObject != null)
            {
                Destroy(currentPlaceableObject);
            }

            currentPlaceableObject = Instantiate(objectsPrefs[number]);
            currentPrefabIndex = number;
        }
    }

    private bool PressedKeyOfCurrentPrefab(int i)
    {
        return currentPlaceableObject != null && currentPrefabIndex == i;
    }

    private void MoveCurrentObjectToMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            currentPlaceableObject.transform.position = hitInfo.point;
            currentPlaceableObject.transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
        }
    }

    private void RotateFromMouseWheel()
    {
        Debug.Log(Input.mouseScrollDelta);
        mouseWheelRotation += Input.mouseScrollDelta.y;
        currentPlaceableObject.transform.Rotate(Vector3.up, mouseWheelRotation * 10f);
    }

    private void ReleaseIfClicked()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentPlaceableObject = null;
        }
    }
}
