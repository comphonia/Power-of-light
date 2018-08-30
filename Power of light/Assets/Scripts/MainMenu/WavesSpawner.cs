using UnityEngine;

public class WavesSpawner : MonoBehaviour {

    [SerializeField] GameObject[] waves;
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
    GameObject wave;
    public static WavesSpawner instance;

    private void Awake()
    {
        if (instance == null) instance = this;
        else this.enabled = false; 

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

    public void TryAgain()
    {
        Destroy(wave);
    }
}
