using System;
using UnityEngine;

public class PlacementController : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsPrefs;
    [SerializeField] LayerMask whereToPlace;
    [SerializeField] LayerMask generatorPlacement;
    [SerializeField] float radius; 

    public static bool building = false;
    static bool moving  = false;

    static GameObject currentPlaceableObject;

    float mouseWheelRotation;
    int currentPrefabIndex = -1;

    RaycastHit hitInfo; 

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

    public static void HandleObject(GameObject obj)
    {
        currentPlaceableObject = obj;
        moving = true;
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
        
        if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity))
        {
            if (currentPrefabIndex == 2)
            {
                if (hitInfo.collider.gameObject.layer == LayerMask.NameToLayer("BaseArea"))
                {
                    currentPlaceableObject.transform.position = hitInfo.point;
                    currentPlaceableObject.transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
                }
            }
            else
            {
                if (hitInfo.collider.gameObject.layer == LayerMask.NameToLayer("Terrain"))
                {
                    currentPlaceableObject.transform.position = hitInfo.point;
                    currentPlaceableObject.transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
                }
            }

        }
    }

    private void RotateFromMouseWheel()
    {
        //Debug.Log(Input.mouseScrollDelta);
        mouseWheelRotation = Input.mouseScrollDelta.y;
        currentPlaceableObject.transform.Rotate(Vector3.up, mouseWheelRotation * 10f);
    }

    private void ReleaseIfClicked()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("released");
            Structure structure = currentPlaceableObject.GetComponent<Structure>();
            int cost = structure.cost;
            if (!moving) GameMaster.instance.Gold -= cost;
            moving = false;
            currentPlaceableObject = null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        if (hitInfo.collider != null) Gizmos.DrawSphere(hitInfo.point, radius); 
    }
}
