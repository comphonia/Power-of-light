using UnityEngine;

public class WavesSpawner : MonoBehaviour {

    public GameObject[] waves;
    int waveNumber;
    int WaveNumber
    {
        get
        {
            return waveNumber;
        }
        set
        {
            waveNumber = value;
            GameMaster.instance.UpdateWaveNumberUI(waveNumber); 
        }
    }
    bool waveInProgress = false;
    bool WaveInProgress
    {
        get
        {
            return waveInProgress;
        }
        set
        {
            waveInProgress = value;
            PlayWaveButton.instance.SetButton(waveInProgress); 
        }
    }
    public static WavesSpawner instance;
    GameObject wave; 

    private void Awake()
    {
        if (instance == null) instance = this;
        else this.enabled = false; 
    }

    private void Start()
    {
        WaveNumber = 0;
    }

    public void StartNewWave()
    {
        WaveInProgress = true;
        wave = Instantiate(waves[waveNumber], transform); 
    }

    public void WaveEnded()
    {
        WaveInProgress = false;
        Destroy(wave);
        WaveNumber++; 
    }

}
