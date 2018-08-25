using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBeamGenerator : MonoBehaviour
{
    public Transform rayOrigin;

    public float maxDistance;

    public bool isPowered;

    public bool drawRay;
    private Reflect reflect;

    void Update ()
    {
        if (isPowered)
        {
            RaycastHit hit;
            if (Physics.Raycast(rayOrigin.position, rayOrigin.TransformDirection(Vector3.forward), out hit, maxDistance))
            {
                if (hit.collider.CompareTag("Mirror"))
                {
                    Vector3 incomingVect = hit.point - rayOrigin.position;
                    Vector3 reflectVect = Vector3.Reflect(incomingVect, hit.normal);
                    reflect = hit.collider.gameObject.GetComponent<Reflect>();
                    reflect.reflectVect = reflectVect;
                    reflect.hitPosition = hit.point;
                    reflect.ReflectBeam();
                }
                if (hit.collider.CompareTag("Tower"))
                {
                    hit.collider.gameObject.GetComponent<Spotlight>().Powered();
                }
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
}
