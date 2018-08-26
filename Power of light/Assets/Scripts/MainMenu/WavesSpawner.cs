using UnityEngine;

public class WavesSpawner : MonoBehaviour {

    static GameObject[] waves;
    static int waveNumber = 0;

    private void Awake()
    { 
        waves = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            waves[i] = transform.GetChild(i).gameObject;
            waves[i].SetActive(false);
        }
    }

    private void Start()
    {
        waves[waveNumber].SetActive(true); 
    }

    public void StartWave()
    {
        waves[waveNumber].SetActive(true); 
    }

    public static void WaveEnded()
    {
        //waves[waveNumber].SetActive(false);
        waveNumber++; 
    }

}
