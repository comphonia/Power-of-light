using System;
using UnityEngine;

public class PlacementController : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsPrefs;
    [SerializeField] LayerMask whereToPlace;

    public static bool building = false;
    static bool gratis = false; 

    static GameObject currentPlaceableObject;

    float mouseWheelRotation;
    int currentPrefabIndex = -1;

    private void Update()
    {
        if (currentPlaceableObject != null)
        {
            building = true;
            if (Input.GetKeyDown(KeyCode.Escape)) Destroy(currentPlaceableObject);
            MoveCurrentObjectToMouse();
            RotateFromMouseWheel();
            ReleaseIfClicked();
        }
        else building = false; 
    }

    public static void HandleObject (GameObject obj)
    {
        currentPlaceableObject = obj;
        gratis = true; 
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
        if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity, whereToPlace))
        {
            currentPlaceableObject.transform.position = hitInfo.point;
            currentPlaceableObject.transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
        }
    }

    private void RotateFromMouseWheel()
    {
        //Debug.Log(Input.mouseScrollDelta);
        mouseWheelRotation += Input.mouseScrollDelta.y;
        currentPlaceableObject.transform.Rotate(Vector3.up, mouseWheelRotation * 10f);
    }

    private void ReleaseIfClicked()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("released");
            Structure structure = currentPlaceableObject.GetComponent<Structure>();
            int cost = structure.cost; 
            if (!gratis) GameMaster.instance.Gold -= cost;
            gratis = false; 
            currentPlaceableObject = null;
        }
    }
}
