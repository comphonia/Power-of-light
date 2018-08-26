using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reflect : MonoBehaviour
{
    public Vector3 reflectVect;

    public Vector3 hitPosition;

    public float maxDistance;

    public LineRenderer lightBeam;

    public Material reflectMat;

    public Material fadeMat;

    RaycastHit hit;

    private Reflect reflect;

    private void Awake()
    {
        lightBeam = GetComponent<LineRenderer>();
    }

    private void LateUpdate()
    {
        lightBeam.enabled = false;
    }

    public void ReflectBeam()
    {
        lightBeam.enabled = true;
        if (Physics.Raycast(hitPosition, reflectVect, out hit, maxDistance))
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
            lightBeam.material = reflectMat;
            lightBeam.SetPosition(0, hitPosition);
            lightBeam.SetPosition(1, hit.point);
        }
        else
        {
            lightBeam.material = fadeMat;
            lightBeam.SetPosition(0, hitPosition);
            lightBeam.SetPosition(1, hitPosition + (reflectVect.normalized * maxDistance));
        }
    } 
}

