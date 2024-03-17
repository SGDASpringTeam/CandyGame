using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Important Components")]
    [SerializeField] private EnemySpawner enemySpawner; // Reference to Enemy Spawner
    [SerializeField] private GameObject resultsScreen; // Reference to Game Over Screen

    private int enemiesDestroyed; // Used if Levels are NOT Endless

    private void Start()
    {
        enemiesDestroyed = 0;
        enemySpawner.StartSpawning();
    }

    public void UpdateEnemiesDestroyed() // Used if Levels are NOT Endless
    {
        if(!enemySpawner.isInfinite && ++enemiesDestroyed == enemySpawner.maxNumberOfEnemies)
        {
            resultsScreen.SetActive(true);
        }
    }
}