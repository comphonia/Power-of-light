using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBeamGenerator : Structure
{
    public Transform rayOrigin;

    public float maxDistance;

    public int maxBounces;

    public static int beamIntensity;

    public bool isPowered;

    public bool drawRay;

    public LineRenderer lightBeam;

    public Material reflectMat;

    public Material fadeMat;

    private Reflect reflect;

    private void Awake()
    {
        beamIntensity = maxBounces;
        lightBeam.enabled = false;
    }

    protected override void Update ()
    {
        base.Update(); 
        lightBeam.enabled = isPowered;
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
                    reflect.isReflecting = true;
                    reflect.beamIntensity = beamIntensity;
                    reflect.reflectVect = reflectVect;
                    reflect.hitPosition = hit.point;
                    //reflect.ReflectBeam();
                }
                if (hit.collider.CompareTag("Tower"))
                {
                    hit.collider.gameObject.GetComponent<Spotlight>().Powered();
                }
                lightBeam.material = reflectMat;
                lightBeam.SetPosition(0, rayOrigin.position);
                lightBeam.SetPosition(1, hit.point);
            }
            else
            {
                lightBeam.material = fadeMat;
                lightBeam.SetPosition(0, rayOrigin.position);
                lightBeam.SetPosition(1, rayOrigin.TransformPoint(Vector3.forward * maxDistance));
            }
        }
    }
}
