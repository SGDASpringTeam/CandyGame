using UnityEngine;

public enum PrimaryType
{
    Spicy,
    Sour,
    Sweet,
}
public enum SecondaryType
{
    Hard,
    Soft,
    Gummy,
}

public class PlayerUnit : MonoBehaviour
{
    [Header("Unit Attributes")]
    public PrimaryType type1;
    public SecondaryType type2;
    public float maxHealth;
    public float currentHealth;
    public float attack;

    // Important Variables for this Script
    private bool deployed;
    private BoxCollider2D hitbox;

    private void Start()
    {
        deployed = false;
        hitbox = GetComponent<BoxCollider2D>();
        hitbox.enabled = false;
    }

    private void Update()
    {
        if(!deployed) ReadyToDeploy();
    }

    private void ReadyToDeploy()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        transform.position = mousePosition;

        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<GridTile>() != null)
                {
                    GridTile selectedTile = hit.collider.GetComponent<GridTile>();
                    if (selectedTile.currentUnit == null)
                    {
                        selectedTile.PlaceUnit(this.gameObject);
                        deployed = true;
                        hitbox.enabled = true;
                        transform.position = hit.collider.gameObject.transform.position;
                        return;
                    }
                }
            }
            Destroy(this.gameObject);
        }
    }
}