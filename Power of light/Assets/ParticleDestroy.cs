using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDestroy : MonoBehaviour
{
    public AudioSource[] growls;

    private int growlSound;

    private void Start()
    {
        growlSound = Random.Range(0, growls.Length);
        growls[growlSound].Play();
        Destroy(gameObject, 5);
    }

}
