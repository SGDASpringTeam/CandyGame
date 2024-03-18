using UnityEngine;

// This script represents the Player Base, not the individual player units

public class PlayerScript : MonoBehaviour
{
    // How many hits the player base can take before Game Over
    public int totalHits;
    private int remainingHits;

    private GameManager gameManager;
    [SerializeField] private GameObject resultsScreen;

    [SerializeField] private AudioClip _gameOverSound;
    [SerializeField] private int _gameOverSoundVolume = 1;

    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        //resultsScreen = GameObject.Find("Results Screen");

        remainingHits = totalHits;
    }

    // Deal Damage to Player Base. Called from EnemyUnit script
    public void TakeDamage()
    {
        if(--remainingHits <= 0)
        {
            resultsScreen.SetActive(true);
            SFXPlayer.PlayClip2D(_gameOverSound, _gameOverSoundVolume);
            Time.timeScale = 0;
        }

        gameManager.UpdateEnemiesDestroyed();
    }
}