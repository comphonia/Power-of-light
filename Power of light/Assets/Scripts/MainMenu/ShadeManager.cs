using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadeManager : MonoBehaviour
{

    [SerializeField] GameObject[] roamerWaypoints;
    public GameObject brokenGlass;

    public GameObject[] angryWaypoints;

    public static ShadeManager instance;
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    public Vector3 WhereTo()
    {
        int val = Random.Range(0, roamerWaypoints.Length);

        return roamerWaypoints[val].transform.position;
    }


}
