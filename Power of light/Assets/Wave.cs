using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {

    int waveNumber = 1;
    [SerializeField] GameObject[] enemyTypes;
    [SerializeField] float[] probs;
    [SerializeField] float spawnDelay; 
    

    private void Awake()
    {
        if (PlayerPrefs.HasKey("waveNumber")) waveNumber = PlayerPrefs.GetInt("waveNumber");
        probs[0] = 100; 
    }
  
    IEnumerator Spawning ()
    {
        int enemyType = ChooseEnemyType();
        yield return new WaitForSeconds(spawnDelay);
        Instantiate(enemyTypes[enemyType], transform.position, Quaternion.identity, transform); 
        yield break; 
    }

    int ChooseEnemyType()
    {
        float number = Random.Range(0, 100);
        float line = 0;
        for (int i = 0; i < probs.Length; i++)
        {
            line += probs[i];
            if (number < line) return i;
        }
        Debug.LogError("Enemy type not chosen");
        return -1;
    }

}
