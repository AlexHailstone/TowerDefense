using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class wavecontroller : MonoBehaviour
{


    public float timeBetweenWaves = 10f;
    private float countdown = 2f;
    public float pauseBetweenWaves = 2f;

    public TextMeshProUGUI waveCountdownText;



    public int waveIndex = 0;
    public Transform enemyPrefab;
    public Transform spawnPoint;
    


    void Update()
    {

        if (countdown <= 0f)
		{
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
           
        }

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        waveCountdownText.text = string.Format("{0:00.00}", countdown);
        countdown -= Time.deltaTime;
        

    }


    IEnumerator SpawnWave ()
	{

        waveIndex++;
        Debug.Log("Wave incoming!");

		for (int i = 0; i < waveIndex; i++)
		{
            SpawnEnemy();
            yield return new WaitForSeconds(pauseBetweenWaves);
		}

        
    }
        

    void SpawnEnemy()
	{
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
	}



}
