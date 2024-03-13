using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public int totalHits;
    private int remainingHits;

    private GameManager gameManager;
    private GameObject resultsScreen;

    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        resultsScreen = GameObject.Find("Results Screen").transform.Find("You Lose...").gameObject;

        remainingHits = totalHits;
    }

    public void TakeDamage()
    {
        if(--remainingHits <= 0)
        {
            resultsScreen.SetActive(true);
            Time.timeScale = 0;
        }

        gameManager.UpdateEnemiesDestroyed();
    }
}