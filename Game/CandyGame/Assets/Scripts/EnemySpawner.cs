/**
 * Author: Alan
 * Contributors: Hudson Green, Matthew Doerr
 * Description: N/A
**/

using UnityEngine;
using System.Collections;
using System;

public class EnemySpawner : MonoBehaviour
{
    // Game can be Endless, or we can have Multiple Levels
    [Header("Mode")]
    public bool isInfinite;
    public int maxNumberOfEnemies;

    private int spawnedEnemies;
    private float gameTime;
    private Coroutine waveRoutine;

    // Which Enemy Units to Spawn, and Lane Positions
    [Header("Important Components")]
    public GameObject[] enemyUnits;
    public Transform[] spawnPositions;

    // How Often Enemies Spawn, or How Long Waves Last
    [Header("Spawn Time Values")]
    public float startTime;
    public float spawnInterval;
    public float waveDuration;
    public int waveCount;

    [Header("Audio Components")]
    [SerializeField] private AudioClip _newWaveSound;
    [SerializeField] private int _newWaveSoundVolume = 1;

    private void Start()
    {
        spawnedEnemies = 0;
        gameTime = 0.0f;
        waveCount = 0;
    }
    private void Update()
    {
        gameTime += Time.deltaTime;
    }

    // Spawn a Random Enemy on a Random Lane
    public void StartSpawning()
    {
        InvokeRepeating(nameof(SpawnEnemies), startTime, spawnInterval);
        if(isInfinite) waveRoutine = StartCoroutine(SlowDownSpawning());
    }
    private void SpawnEnemies()
    {
        if (isInfinite || spawnedEnemies < maxNumberOfEnemies)
        {
            GameObject enemyUnit = enemyUnits[UnityEngine.Random.Range(0, enemyUnits.Length)];
            Transform spawnPosition = spawnPositions[UnityEngine.Random.Range(0, spawnPositions.Length)];
            Instantiate(enemyUnit, spawnPosition.position, Quaternion.identity);
        }

        if(!isInfinite) spawnedEnemies++; // Level Ends when certain number of enemies spawn
    }

    // Give the Player a Brief Break before Enemies spawn again
    IEnumerator SlowDownSpawning() // If isInfinite
    {
        yield return new WaitForSeconds(waveDuration);
        CancelInvoke(nameof(SpawnEnemies));

        // increments the wave # for every wave
        ++waveCount;
        SFXPlayer.PlayClip2D(_newWaveSound, _newWaveSoundVolume);
        StartSpawning();
    }
}