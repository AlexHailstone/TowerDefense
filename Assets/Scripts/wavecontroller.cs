using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class wavecontroller : MonoBehaviour
{
    public static int enemiesAlive = 0;


    public float timeBetweenWaves = 10f;
    private float countdown = 2f;

    public TextMeshProUGUI waveCountdownText;



    private int waveIndex = 0;
    public Transform enemyPrefab;
    public Transform spawnPoint;

    public Wave[] waves;




    void Update()
    {
        if (enemiesAlive > 0)
            return; 


        if (countdown <= 0f)
		{
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
           
        }

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        waveCountdownText.text = string.Format("{0:00.00}", countdown);
        countdown -= Time.deltaTime;
        

    }


    IEnumerator SpawnWave ()
	{

        PlayerStats.rounds++;

        Wave wave = waves[waveIndex];

		for (int i = 0; i < wave.count; i++)
		{
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
		}

        waveIndex++;

        if (waveIndex == waves.Length)
		{
            //This is reaching the max level.
            Debug.Log("End of The Level");
            this.enabled = false;
		}
        
    }
        

    void SpawnEnemy(GameObject enemy)
	{
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        enemiesAlive++;
	}



}
