using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tower : MonoBehaviour {

    protected float range;
    protected LayerMask whatToHit;
    protected Transform target;

    void FindTarget()
    {
        float smallestDistance = Mathf.Infinity;
        Transform nearestEnemy = null;
        Collider[] hits = Physics.OverlapSphere(transform.position, range, whatToHit);

        foreach (Collider h in hits)
        {
            float distance = Vector3.Distance(h.transform.position, transform.position);
            if (distance < smallestDistance)
            {
                smallestDistance = distance;
                nearestEnemy = h.transform;
            }
        }

        target = nearestEnemy;
    }
}
