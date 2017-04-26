using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

    public Transform enemyPrefab;
    public Transform speedEnemyPrefab;
    public Transform heavyEnemyPrefab;
    public Transform bossEnemyPrefab;

    public Transform elite_enemyPrefab;
    public Transform elite_speedEnemyPrefab;
    public Transform elite_heavyEnemyPrefab;
    public Transform elite_bossEnemy;

    public Transform spawnPoint;

    public float waveIncrementTime = 15f;
    private float countdown = 5f;

    public Text waveCountdownText;
    public Text waveText;
    public Text livesText;


    public int waveNo = 1;

    public float SpawnWaitTime = 5f;


    //Temporary
    public Text oilText;



    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = waveIncrementTime;
        }

        countdown -= Time.deltaTime;
        waveCountdownText.text = "Next wave in: " + Math.Floor(countdown).ToString();
        oilText.text = PlayerVariables.Oil.ToString();


        //TEMP _ MOVE WHEN MVC SWITCH HAPPENS
        livesText.text = PlayerVariables.Lives.ToString();

        if(waveNo > 35)
        {
            waveIncrementTime = 20f;
        }

        if (waveNo > 75)
        {
            waveIncrementTime = 10f;
        }
    }

    IEnumerator SpawnWave()
    {
        waveNo++;
        PlayerVariables.WavesSurvived++;
        waveText.text = "Wave " + waveNo.ToString();
        Debug.Log("Wave "+waveNo+" Incoming!");

        if (waveNo == 10)
        {
            waveCountdownText.text = "Level 10 Bonus!";
            PlayerVariables.Cash += 100;
        }

        if (waveNo == 20)
        {
            waveCountdownText.text = "Level 20 Bonus!";
            PlayerVariables.Cash += 200;
        }

        if (waveNo < 15)
        {
            for (int i = 0; i < waveNo; i++)
            {
                SpawnEnemy(enemyPrefab);
                yield return new WaitForSeconds(SpawnWaitTime);
            }


        }

        if (waveNo > 15 && waveNo < 25)
        {
            SpawnEnemy(heavyEnemyPrefab);
            yield return new WaitForSeconds(SpawnWaitTime);

            for (int i = 0; i < waveNo; i++)
            {
                SpawnEnemy(enemyPrefab);
                yield return new WaitForSeconds(SpawnWaitTime);
            }

            SpawnEnemy(heavyEnemyPrefab);
            yield return new WaitForSeconds(SpawnWaitTime);


        }

        if (waveNo > 25 && waveNo < 35)
        {
            for (int i = 0; i < waveNo; i++)
            {
                SpawnEnemy(enemyPrefab);
                yield return new WaitForSeconds(SpawnWaitTime);
            }

            for (int i = 0; i < waveNo/5; i++)
            {
                SpawnEnemy(speedEnemyPrefab);
                yield return new WaitForSeconds(SpawnWaitTime);
            }

            SpawnEnemy(heavyEnemyPrefab);
            yield return new WaitForSeconds(SpawnWaitTime);

            SpawnEnemy(heavyEnemyPrefab);
            yield return new WaitForSeconds(SpawnWaitTime);

            SpawnEnemy(heavyEnemyPrefab);
            yield return new WaitForSeconds(SpawnWaitTime);

        }

        if (waveNo == 30)
        {
            waveCountdownText.text = "Level 30 Bonus!";
            PlayerVariables.Cash += 450;
        }

        if (waveNo > 35 && waveNo < 45)
        {
            for (int i = 0; i < waveNo; i++)
            {
                SpawnEnemy(enemyPrefab);
                yield return new WaitForSeconds(SpawnWaitTime);
            }

            for (int i = 0; i < waveNo /2.5; i++)
            {
                SpawnEnemy(speedEnemyPrefab);
                yield return new WaitForSeconds(SpawnWaitTime);
            }

            for (int i = 0; i < waveNo /15; i++)
            {
                SpawnEnemy(heavyEnemyPrefab);
                yield return new WaitForSeconds(2f);
            }

        }

        if(waveNo == 40)
        {
            SpawnEnemy(bossEnemyPrefab);
        }

        if (waveNo > 40 && waveNo < 50)
        {
            SpawnEnemy(elite_heavyEnemyPrefab);
            yield return new WaitForSeconds(2f);

            for (int i = 0; i < waveNo; i++)
            {
                SpawnEnemy(enemyPrefab);
                yield return new WaitForSeconds(SpawnWaitTime);
            }
                        
            for (int i = 0; i < waveNo/15; i++)
            {
                SpawnEnemy(heavyEnemyPrefab);
                yield return new WaitForSeconds(2f);
            }

            SpawnEnemy(elite_heavyEnemyPrefab);
            yield return new WaitForSeconds(2f);

        }
        if (waveNo == 50)
        {
            SpawnEnemy(bossEnemyPrefab);
            yield return new WaitForSeconds(2f);

            SpawnEnemy(bossEnemyPrefab);
            yield return new WaitForSeconds(3f);

            SpawnEnemy(bossEnemyPrefab);
            yield return new WaitForSeconds(3f);

            SpawnEnemy(elite_bossEnemy);
            yield return new WaitForSeconds(4f);

            yield return new WaitForSeconds(20f);
        }



        if (waveNo > 70)
        {
            for (int i = 0; i < waveNo/8; i++)
            {
                SpawnEnemy(elite_enemyPrefab);
                yield return new WaitForSeconds(SpawnWaitTime);
            }

            for (int i = 0; i < waveNo/7; i++)
            {
                SpawnEnemy(elite_speedEnemyPrefab);
                yield return new WaitForSeconds(SpawnWaitTime);
            }

            SpawnEnemy(elite_bossEnemy);
            yield return new WaitForSeconds(5f);

        }

        

        
    }

    void SpawnEnemy(Transform enemyPrefab)
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

}
