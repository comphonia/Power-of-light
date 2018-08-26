using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class GoldText : MonoBehaviour {

    static TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>(); 
    }

    public static void UpdateText(int value)
    {
        text.text = string.Format(value.ToString()); 
    }

}
