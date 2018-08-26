using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {

    [System.Serializable]
    class SubWave
    {
        public GameObject enemy;
        public float numberOfEnemy;
        public float spawnDelay;
        public float delayToNextSubWave; 
    }

    [SerializeField] List<SubWave> subWaves;
    [SerializeField] float delayWhenTheWaveStarts;
    int lastingEnemies;
    public int LastingEnemies
    {
        get
        {
            return lastingEnemies;
        }
        set
        {
            lastingEnemies = value;
            UpdateLastingEnemiesUI();
            if (lastingEnemies == 0) WaveEnded(); 
        }
    }
    
    /*[SerializeField] GameObject[] enemyTypes;
    [SerializeField] float[] probs;
    [SerializeField] float spawnDelay;
    [SerializeField] float numberOfEnemy; */
    

    private void OnEnable()
    {
        StartCoroutine(Spawning()); 
    }

    IEnumerator Spawning()
    {
        /*for (int i = 0; i < numberOfEnemy; i++)
        { 
            int enemyType = ChooseEnemyType();
            yield return new WaitForSeconds(spawnDelay);
            Instantiate(enemyTypes[enemyType], transform.position, Quaternion.identity, transform);
        }
        yield break; */
        yield return new WaitForSeconds(delayWhenTheWaveStarts);
        foreach(SubWave sw in subWaves)
        {
            for (int i = 0; i < sw.numberOfEnemy; i++)
            {
                Instantiate(sw.enemy, transform.position, Quaternion.identity, transform);
                yield return new WaitForSeconds(sw.spawnDelay);
            }
            yield return new WaitForSeconds(sw.delayToNextSubWave); 
        }
    }

    void WaveEnded()
    {
        Debug.Log("wave ended");
        GameMaster.instance.WaveEnded();
        WavesSpawner.WaveEnded();
    }

    void UpdateLastingEnemiesUI()
    {

    }

    /*int ChooseEnemyType()
    {
        float number = Random.Range(0, 100);
        //Debug.Log("random number " + number); 
        float line = 0;
        for (int i = 0; i < probs.Length; i++)
        {
            line += probs[i];
            //Debug.Log("line: " + line);
            if (number <= line) return i;
        }
        Debug.LogError("Enemy type not chosen");
        return -1;
    }*/

}
