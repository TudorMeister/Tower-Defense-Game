using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public SpawnPoint[] SpawnPoints;
    public float timeBetweenWaves = 5f;
    private float countdown = 2f;
    private int countdownToDisplay = 3;
    private int waveIndex = 1;

    private SpawnPoint[] _selectedSpawnPoints;
    private int[] _selectedSpawnPointsEnemyCount;

    void Start()
    {
        UpdateSelectedSpawnPoints();
        _selectedSpawnPointsEnemyCount = ComputeEnemiesPerSpawnpoint(waveIndex*2);
        ShowHolograms();
    }

    // Update is called once per frame
    void Update()
    {
        if (countdown <= 0f)
        {
            SpawnWave();
            countdown = timeBetweenWaves;
            countdownToDisplay = (int)countdown;
        }

        if (countdown <= countdownToDisplay)
        {
            countdownToDisplay = (int)Mathf.Floor(countdown);
            UpdateHolograms();
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
        ClearHolograms();

        for (int i = 0; i < _selectedSpawnPoints.Length; i++)
        {
            StartCoroutine(SpawnWaveForSpawnPoint(_selectedSpawnPoints[i], _selectedSpawnPointsEnemyCount[i]));
        }

        UpdateSelectedSpawnPoints();
        _selectedSpawnPointsEnemyCount = ComputeEnemiesPerSpawnpoint(waveIndex*2);
        ShowHolograms();
    }

    IEnumerator SpawnWaveForSpawnPoint(SpawnPoint SpawnPoint, int NumberOfEnemies)
    {
        for (int i = 0; i < NumberOfEnemies; i++) 
        {
            SpawnEnemy(SpawnPoint);
            yield return new WaitForSeconds(0.3f);
        }
    }

    void SpawnEnemy(SpawnPoint SpawnPoint)
    {
        Instantiate(enemyPrefab, SpawnPoint.transform.position, SpawnPoint.transform.rotation);
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

    void ClearHolograms()
    {
        foreach (SpawnPoint spawnPoint in _selectedSpawnPoints)
        {
            spawnPoint.SetHologramVisibility(false);
        }
    }

    void ShowHolograms()
    {
        for (int i = 0; i < _selectedSpawnPoints.Length; i++)
        {
            if (_selectedSpawnPointsEnemyCount[i] == 0)
                continue;

            _selectedSpawnPoints[i].SetHologramVisibility(true);
        }
    }


    void UpdateHolograms()
    {
        for (int i=0;i<_selectedSpawnPoints.Length; i++)
        {
            UpdateHologramContent(i);
        }
    }

    void UpdateHologramContent(int selectedSpawnPointIndex)
    {
        SpawnPoint spawnPoint = _selectedSpawnPoints[selectedSpawnPointIndex];
        int enemiesCount = _selectedSpawnPointsEnemyCount[selectedSpawnPointIndex];
        int countdownToDisplay = this.countdownToDisplay + 1;

        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append(_selectedSpawnPointsEnemyCount[selectedSpawnPointIndex]);
        if (enemiesCount == 1)
            stringBuilder.Append(" enemy ");
        else
            stringBuilder.Append(" enemies ");
        stringBuilder.Append("will spawn here in ");
        stringBuilder.Append(countdownToDisplay);
        if (countdownToDisplay == 1)
            stringBuilder.Append(" second.");
        else
            stringBuilder.Append(" seconds.");

        spawnPoint.SetHologramContent(stringBuilder.ToString());
    }
}
