using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPresentation : MonoBehaviour {

    [SerializeField] AudioClip sound;
    [SerializeField] GameObject showPanel;

    private void Awake()
    {
        showPanel.SetActive(true);
        AudioSource audioS = gameObject.AddComponent<AudioSource>();
        audioS.clip = sound;
        audioS.Play(); 
        Destroy(showPanel, 6f); 
    }
}
