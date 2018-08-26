using System.Collections;
using System.Collections.Generic;
using TMPro; 
using UnityEngine;

public class LastingEnemiesText : MonoBehaviour {

    TextMeshProUGUI text;
    public static LastingEnemiesText instance; 

    private void Awake()
    {
        if (instance == null) instance = this;
        else this.enabled = false; 
        text = GetComponent<TextMeshProUGUI>(); 
    }

    public void UpdateText (int value)
    {
        text.text = string.Format(value.ToString());
    }
}
