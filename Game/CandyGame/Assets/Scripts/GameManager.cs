using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Important Components")]
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private GameObject resultsScreen;

    private int enemiesDestroyed;

    private void Start()
    {
        enemiesDestroyed = 0;
        enemySpawner.StartSpawning();
    }

    public void UpdateEnemiesDestroyed()
    {
        if(!enemySpawner.isInfinite && ++enemiesDestroyed == enemySpawner.maxNumberOfEnemies)
        {
            resultsScreen.SetActive(true);
        }
    }
}