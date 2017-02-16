using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

    public Transform enemyPrefab;
    public Transform spawnPoint;

    public float waveIncrementTime = 10f;
    private float countdown = 5f;

    public Text waveCountdownText;
    public Text waveText;


    private int waveNo = 1;


    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = waveIncrementTime;
        }

        countdown -= Time.deltaTime;
        waveCountdownText.text = "Next wave in: " + Math.Floor(countdown).ToString();
    }

    IEnumerator SpawnWave()
    {
        waveNo++;
        waveText.text = "Wave " + waveNo.ToString();
        Debug.Log("Wave "+waveNo+" Incoming!");

        for (int i=0; i< waveNo; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }

        
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

}
