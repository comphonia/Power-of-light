using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    [SerializeField] LayerMask whereToPlace;

    RaycastHit hit;

	void Update ()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, whereToPlace ))
        {
            transform.position = hit.point;
            transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
        }
            
	}
}
