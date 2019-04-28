using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int waveIndex = 0;
    public GameObject[] liveEnemies;
    public bool isWaveFinished = true;
    private int enemiesGenerated;
    public int enemyNum = 0;
    public bool hasGameStarted = false;
    public bool wasRewardGiven = false;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        liveEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (liveEnemies.Length == 0 && enemiesGenerated == enemyNum && hasGameStarted == true)
        {
            isWaveFinished = true;
            if (wasRewardGiven == false)
            {
                GameObject.FindGameObjectWithTag("Castle").GetComponent<castleLogic>().pointsToNextHeart += ((2.71f * (waveIndex + 1) * 0.2f) + 2f);
                wasRewardGiven = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && isWaveFinished == true)
        {
            if (hasGameStarted == false)
            {
                hasGameStarted = true;
            }

            SpawnWave();
            wasRewardGiven = false;
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        if (enemiesGenerated < enemyNum)
        {
            enemiesGenerated++;
            Invoke("SpawnEnemy", 1f);
        }
        else
        {
            waveIndex++;
        }
    }

    void SpawnWave()
    { 
        enemiesGenerated = 0;
        isWaveFinished = false;
        enemyNum = Mathf.RoundToInt((waveIndex + 1) * 0.85f * 2.71f);
        SpawnEnemy();       
    }
}
