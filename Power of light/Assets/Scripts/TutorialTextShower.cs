using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTextShower : MonoBehaviour {

    [SerializeField] GameObject tutorialPanel;

    private void Awake()
    {
        tutorialPanel.SetActive(true); 
    }
}
