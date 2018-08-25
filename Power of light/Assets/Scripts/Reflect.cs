using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reflect : MonoBehaviour
{
    public Vector3 reflectVect;

    public Vector3 hitPosition;

    public float maxLength;

    RaycastHit hit;

    private Reflect reflect;

    public void ReflectBeam()
    {
        if (Physics.Raycast(hitPosition, reflectVect, out hit, maxLength))
        {
            if (hit.collider.CompareTag("Mirror"))
            {
                Vector3 incomingVect = hit.point - hitPosition;
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
            Debug.DrawRay(hitPosition, reflectVect.normalized * hit.distance, Color.white);
        }
        else
        {
            Debug.DrawRay(hitPosition, reflectVect * maxLength, Color.white);
        } 
        
    }
}

