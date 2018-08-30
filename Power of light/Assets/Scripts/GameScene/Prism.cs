using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prism : MonoBehaviour
{
    public LineRenderer beam1;
    public LineRenderer beam2;

    RaycastHit hit1;
    RaycastHit hit2;

    public bool isSplitting;
    public float maxDistance;
    public Vector3 hitPosition;
    public Vector3 beam1dir;
    private Reflect reflect;
    public Material reflectMat;
    public Material fadeMat;
    public Vector3 beam2dir;
    public int beamIntensity;
    public GameObject pointLight;

    private void Update()
    {
        beam1.enabled = isSplitting;
        beam2.enabled = isSplitting;
        pointLight.SetActive(isSplitting);
        if (isSplitting)
        {
            SplitBeam(beamIntensity);
        }
    }

    public void SplitBeam(int intensity)
    {
        intensity -= 1;
        float colorValue = Mathf.InverseLerp(0, LightBeamGenerator.beamIntensity, intensity);
        beam1.startColor = new Color(colorValue, colorValue, colorValue);
        beam1.endColor = new Color(colorValue, colorValue, colorValue);
        beam2.startColor = new Color(colorValue, colorValue, colorValue);
        beam2.endColor = new Color(colorValue, colorValue, colorValue);
        if (intensity <= 0)
        {
            isSplitting = false;
            return;
        }
        if (Physics.Raycast(hitPosition, beam1dir, out hit1, maxDistance))
        {
            if (hit1.collider.CompareTag("Mirror"))
            {
                Vector3 incomingVect = hit1.point - hitPosition;
                Vector3 reflectVect = Vector3.Reflect(incomingVect, hit1.normal);
                reflect = hit1.collider.gameObject.GetComponent<Reflect>();
                reflect.isReflecting = true;
                reflect.beamIntensity = intensity;
                reflect.reflectVect = reflectVect;
                reflect.hitPosition = hit1.point;
            }
            if (hit1.collider.CompareTag("Tower"))
            {
                hit1.collider.gameObject.GetComponent<Spotlight>().Powered();
            }
            beam1.material = reflectMat;
            beam1.SetPosition(0, hitPosition);
            beam1.SetPosition(1, hit1.point);
        }
        else
        {
            beam1.material = fadeMat;
            beam1.SetPosition(0, hitPosition);
            beam1.SetPosition(1, hitPosition + (beam1dir.normalized * maxDistance));
        }
        if (Physics.Raycast(hitPosition, beam2dir, out hit2, maxDistance))
        {
            if (hit2.collider.CompareTag("Mirror"))
            {
                Vector3 incomingVect = hit2.point - hitPosition;
                Vector3 reflectVect = Vector3.Reflect(incomingVect, hit2.normal);
                reflect = hit2.collider.gameObject.GetComponent<Reflect>();
                reflect.isReflecting = true;
                reflect.beamIntensity = intensity;
                reflect.reflectVect = reflectVect;
                reflect.hitPosition = hit2.point;
            }
            if (hit2.collider.CompareTag("Tower"))
            {
                hit2.collider.gameObject.GetComponent<Spotlight>().Powered();
            }
            beam2.material = reflectMat;
            beam2.SetPosition(0, hitPosition);
            beam2.SetPosition(1, hit2.point);
        }
        else
        {
            beam2.material = fadeMat;
            beam2.SetPosition(0, hitPosition);
            beam2.SetPosition(1, hitPosition + (beam2dir.normalized * maxDistance));
        }
        isSplitting = false;
    }
}
