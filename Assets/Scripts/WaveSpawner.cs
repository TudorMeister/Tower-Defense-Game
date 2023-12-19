using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] SpawnPoints;
    public float timeBetweenWaves = 5f;
    private float countdown = 2f;
    private int waveIndex = 0;

    private Transform[] _selectedSpawnPoints;
    private int[] _selectedSpawnPointsEnemyCount;

    // Update is called once per frame
    void Update()
    {
        if (countdown <= 0f)
        {
            SpawnWave();
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
    }

    void UpdateSelectedSpawnPoints()
    {
        int numberOfSpawnpoints = SpawnPoints.Length / 2;
        if (_selectedSpawnPoints == null)
        {
            _selectedSpawnPoints = SpawnPoints.Take(numberOfSpawnpoints).ToArray();
            return;
        }
        ShuffleSpawnPoints();
        _selectedSpawnPoints = SpawnPoints.Take(numberOfSpawnpoints).ToArray();
    }

    void SpawnWave()
    {
        waveIndex++;
        UpdateSelectedSpawnPoints();
        _selectedSpawnPointsEnemyCount = ComputeEnemiesPerSpawnpoint(waveIndex*2);

        // for (int i = 0; i < waveIndex; i++) 
        // {
        //     SpawnEnemy();
        //     yield return new WaitForSeconds(0.3f);
        // }

        for (int i = 0; i < _selectedSpawnPoints.Length; i++)
        {
            StartCoroutine(SpawnWaveForSpawnPoint(_selectedSpawnPoints[i], _selectedSpawnPointsEnemyCount[i]));
        }

    }

    IEnumerator SpawnWaveForSpawnPoint(Transform SpawnPoint, int NumberOfEnemies)
    {
        for (int i = 0; i < NumberOfEnemies; i++) 
        {
            SpawnEnemy(SpawnPoint);
            yield return new WaitForSeconds(0.3f);
        }
    }

    void SpawnEnemy(Transform SpawnPoint)
    {
        Instantiate(enemyPrefab, SpawnPoint.position, SpawnPoint.rotation);
    }


    void ShuffleSpawnPoints()
    {
        // Fisher-Yates shuffle algorithm
        for (int i = SpawnPoints.Length - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            (SpawnPoints[randomIndex], SpawnPoints[i]) = (SpawnPoints[i], SpawnPoints[randomIndex]);
        }
    }

    int[] ComputeEnemiesPerSpawnpoint(int NumberOfEnemies)
    {
        int[] toReturn = new int[_selectedSpawnPoints.Length];

        for (int i = 0; i < _selectedSpawnPoints.Length; i++)
        {
            // Generate a random number of enemies for each spawn point
            int enemiesForSpawnPoint = Random.Range(0, NumberOfEnemies);
            toReturn[i] = enemiesForSpawnPoint;
            NumberOfEnemies -= enemiesForSpawnPoint;
        }

        // Distribute any remaining enemies randomly
        for (int i = 0; i < NumberOfEnemies; i++)
        {
            int randomIndex = Random.Range(0, _selectedSpawnPoints.Length);
            toReturn[randomIndex]++;
        }

        return toReturn;
    }
}
