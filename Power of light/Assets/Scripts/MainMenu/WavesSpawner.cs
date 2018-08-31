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
    public bool WaveInProgress
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

    [SerializeField] GameObject arrowPref; 
    [SerializeField] float spawnArrowsDelay = 0.5f;
    float timer = 0;

    private void Awake()
    {
        if (instance == null) instance = this;
        else this.enabled = false; 
    }

    private void Start()
    {
        WaveNumber = 0;
    }

    private void Update()
    {
        if (!WaveInProgress)
        {
            if (timer <= 0)
            {
                Instantiate(arrowPref, transform.position, Quaternion.identity, transform);
                timer = spawnArrowsDelay; 
            }
            timer -= Time.deltaTime; 
        }
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

    public void BattleLost()
    {
        WaveInProgress = false;
        Destroy(wave);
    }

}
