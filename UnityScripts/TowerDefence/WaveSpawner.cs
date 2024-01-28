using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    // public static int EnemiesAlive = 0;

	// public Wave[] waves;

	public Transform spawnPoint;
    public Transform enemyPrefab;

	public float timeBetweenWaves = 3f;
	private float countdown = 2f;
 
	public TextMeshProUGUI waveCountdownText;

	// public GameManager gameManager;

	private int waveIndex = 0;

	void Update ()
	{
		// if (EnemiesAlive > 0)
		// {
		// 	return;
		// }

		// if (waveIndex == waves.Length)
		// {
			// gameManager.WinLevel();
			// this.enabled = false;
		// }

		if (countdown <= 0f)
		{
			StartCoroutine(SpawnWave());
			countdown = timeBetweenWaves;
			return;
		}

		countdown -= Time.deltaTime;

		countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

		waveCountdownText.text = string.Format("{0:00.00}", countdown);
	}

	IEnumerator SpawnWave ()
	{
		// PlayerStats.Rounds++;

		// Wave wave = waves[waveIndex];

		// EnemiesAlive = wave.count;
        waveIndex++;

		for (int i = 0; i < waveIndex; i++)
		{
			SpawnEnemy(); //did changes
			yield return new WaitForSeconds(0.5f); //did changes
		}

		// waveIndex++;
	}

	void SpawnEnemy ()
	{
		
		Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
	}
}
