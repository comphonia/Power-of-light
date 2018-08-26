using System.Collections;
using System.Collections.Generic;
using TMPro; 
using UnityEngine;

public class LastingEnemiesText : MonoBehaviour {

    static TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>(); 
    }

    public static void UpdateText (int value)
    {
        text.text = string.Format(value.ToString());
    }
}
