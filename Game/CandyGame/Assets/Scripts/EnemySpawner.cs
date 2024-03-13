using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [Header("Mode")]
    public bool isInfinite;
    public int maxNumberOfEnemies;

    private int spawnedEnemies;
    private float gameTime;
    private Coroutine waveRoutine;

    [Header("Important Components")]
    public GameObject[] enemyUnits;
    public Transform[] spawnPositions;

    [Header("Spawn Time Values")]
    public float startTime;
    public float spawnInterval;
    public float waveDuration;

    private void Start()
    {
        spawnedEnemies = 0;
        gameTime = 0.0f;
    }
    private void Update()
    {
        gameTime += Time.deltaTime;
    }

    public void StartSpawning()
    {
        InvokeRepeating(nameof(SpawnEnemies), startTime, spawnInterval);
        if(isInfinite) waveRoutine = StartCoroutine(SlowDownSpawning());
    }
    private void SpawnEnemies()
    {
        if (isInfinite || spawnedEnemies < maxNumberOfEnemies)
        {
            GameObject enemyUnit = enemyUnits[Random.Range(0, enemyUnits.Length)];
            Transform spawnPosition = spawnPositions[Random.Range(0, spawnPositions.Length)];
            Instantiate(enemyUnit, spawnPosition.position, Quaternion.identity);
        }

        if(!isInfinite) spawnedEnemies++;
    }

    IEnumerator SlowDownSpawning() // If isInfinite
    {
        yield return new WaitForSeconds(waveDuration);
        CancelInvoke(nameof(SpawnEnemies));

        StartSpawning();
    }
}