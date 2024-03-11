using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyUnits;
    public Transform[] spawnPositions;

    [Header("Spawn Time Values")]
    public float startTime;
    public float spawnInterval;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnEnemies), startTime, spawnInterval);
    }

    private void SpawnEnemies()
    {
        GameObject enemyUnit = enemyUnits[Random.Range(0, enemyUnits.Length)];

        Transform spawnPosition = spawnPositions[Random.Range(0, spawnPositions.Length)];

        Instantiate(enemyUnit, spawnPosition.position, Quaternion.identity);
    }
}