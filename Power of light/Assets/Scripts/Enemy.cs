using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    float health; 
    public float Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
            if (health <= 0)
            {
                Destroy(gameObject);
                GameMaster.instance.IncreaseGold(lootAmount); 
            }
        }
    }
    [SerializeField] float maxHealth;
    public float defaultSpeed;
    [HideInInspector] public float speed;
    [SerializeField] float lootAmount; 

    Vector3 direction; 
    Transform target;
    int pointIndex = 0;

    private void Awake()
    {
        Health = maxHealth;
        speed = defaultSpeed; 
        target = Waypoints.points[pointIndex];
        transform.LookAt(target);
    }

    private void Update()
    {
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
