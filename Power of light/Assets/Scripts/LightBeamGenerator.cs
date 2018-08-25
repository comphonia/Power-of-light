using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBeamGenerator : MonoBehaviour
{
    public Transform rayOrigin;

    public float maxDistance;

    public bool drawRay;

	void Update ()
    {
        RaycastHit hit;
        if (Physics.Raycast(rayOrigin.position, rayOrigin.TransformDirection(Vector3.forward), out hit, maxDistance))
        {
            if (drawRay)
            {
                Debug.DrawRay(rayOrigin.position, rayOrigin.TransformDirection(Vector3.forward) * hit.distance, Color.white);
            }
            
        }
        else
        {
            if (drawRay)
            {
                Debug.DrawRay(rayOrigin.position, rayOrigin.TransformDirection(Vector3.forward) * maxDistance, Color.white);
            }            
        }

    }
}
