using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathLighter : MonoBehaviour
{
    public float speed;

    Vector3 direction;
    Transform target;
    int pointIndex = 0;

    private void Awake()
    {
        target = Waypoints.points[pointIndex];
        transform.LookAt(target);
    }

    private void Update()
    {
        if (WavesSpawner.instance.WaveInProgress) Destroy(gameObject); 

        direction = target.transform.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
        if (Vector3.Distance(target.transform.position, transform.position) <= 0.2f) GetNewWaypoint();
    }

    void GetNewWaypoint()
    {
        if (pointIndex == Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
        }
        else
        {
            pointIndex++;
            target = Waypoints.points[pointIndex];
            transform.LookAt(target);
            direction = target.transform.position - transform.position;
        }
    }
}
