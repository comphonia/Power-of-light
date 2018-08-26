using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reflect : MonoBehaviour
{
    public bool isReflecting;

    public Vector3 reflectVect;

    public Vector3 hitPosition;

    public float maxDistance;

    private LineRenderer lightBeam;

    public GameObject spotLight;

    public Material reflectMat;

    public Material fadeMat;

    public int beamIntensity;

    RaycastHit hit;

    private Reflect reflect;

    private void Awake()
    {
        lightBeam = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        lightBeam.enabled = isReflecting;
        spotLight.SetActive(isReflecting);
        if (isReflecting)
        {
            ReflectBeam(beamIntensity);
        }
    }

    public void ReflectBeam(int intensity)
    {
        intensity -= 1;
        float colorValue = Mathf.InverseLerp(0, LightBeamGenerator.beamIntensity, intensity);
        lightBeam.startColor = new Color(colorValue, colorValue, colorValue);
        lightBeam.endColor = new Color(colorValue, colorValue, colorValue);
        if (intensity <= 0)
        {
            isReflecting = false;
            return;
        }
        if (Physics.Raycast(hitPosition, reflectVect, out hit, maxDistance))
        {
            if (hit.collider.CompareTag("Mirror"))
            {
                Vector3 incomingVect = hit.point - hitPosition;
                Vector3 reflectVect = Vector3.Reflect(incomingVect, hit.normal);
                reflect = hit.collider.gameObject.GetComponent<Reflect>();
                reflect.isReflecting = true;
                reflect.beamIntensity = intensity;
                reflect.reflectVect = reflectVect;
                reflect.hitPosition = hit.point;
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
        isReflecting = false;
    } 
}

