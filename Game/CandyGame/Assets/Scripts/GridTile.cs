using UnityEngine;

public class GridTile : MonoBehaviour
{
    public bool placeable; // Can the player place a unit on this space
    public GameObject currentUnit; // The current unit occupying this space (player or enemy)

    [SerializeField] private GameObject highlight;

    // Let the game know a unit is occupying this space
    public void PlaceUnit(GameObject placedUnit)
    {
        currentUnit = placedUnit;
    }

    // Show that the player is hovering over the space
    private void OnMouseEnter()
    {
        if(placeable && currentUnit == null) highlight.SetActive(true);
    }
    private void OnMouseExit()
    {
        if(placeable) highlight.SetActive(false);
    }
}