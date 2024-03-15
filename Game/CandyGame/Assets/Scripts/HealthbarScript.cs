using UnityEngine;

public class HealthbarScript : MonoBehaviour
{
    Vector3 initialScale;
    float maxWidth;

    private void Start()
    {
        initialScale = transform.localScale;
        maxWidth = initialScale.x;
    }

    public void UpdateHealthBar(float currentHealth, float maxHealth)
    {
        float healthRatio = currentHealth / maxHealth;
        float newWidth = Mathf.Clamp01(healthRatio) * maxWidth;

        Vector3 newScale = initialScale;
        newScale.x = newWidth;

        transform.localScale = newScale;
    }
}