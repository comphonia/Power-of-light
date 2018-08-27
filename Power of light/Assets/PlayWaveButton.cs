using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class PlayWaveButton : MonoBehaviour {

    Button playButton;
    TextMeshProUGUI playText;
    public static PlayWaveButton instance; 

    private void Awake()
    {
        if (instance == null) instance = this;
        else this.enabled = false;

        playButton = GetComponent<Button>();
        playText = GetComponentInChildren<TextMeshProUGUI>();

        playButton.onClick.AddListener(delegate { WavesSpawner.instance.StartNewWave(); }); 
    }

    public void SetButton(bool value)
    {
        playButton.interactable = !value;
    }

    
}
