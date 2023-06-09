using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public static int enemiesAlive = 0;

    public Wave[] waves;

    public Transform spawnPoint;

    public float timeBetweenWaves = 4f;
    private float countdown = 2f;

    public TextMeshProUGUI waveCountdownText;

    private int waveIndex = 0;

    private void Update()
    {

        if(enemiesAlive > 0)
        {
            return;
        }

        if (countdown <= 0f)
        {
            Debug.Log("How many time did i enter spawn wave function?");
            StartCoroutine(SpawnWave());

            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;
        countdown =  Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownText.text = string.Format("{0:00.00}", countdown);
    }

    IEnumerator SpawnWave()
    {
        PlayerStats.RoundsPlayed++;

        Wave wave = waves[waveIndex];

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f/wave.rate);
        }
        
        waveIndex++;

        if(waveIndex == waves.Length)
        {
            Debug.Log("Level won!");
            this.enabled = false;
        }
    }

    private void SpawnEnemy(GameObject enemyPrefab)
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        enemiesAlive++;
    }
}
