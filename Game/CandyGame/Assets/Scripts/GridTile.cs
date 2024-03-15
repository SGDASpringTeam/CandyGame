using UnityEngine;

public class GridTile : MonoBehaviour
{
    public bool placeable;
    public GameObject currentUnit;

    [SerializeField] private GameObject highlight;

    public void PlaceUnit(GameObject placedUnit)
    {
        currentUnit = placedUnit;
    }

    private void OnMouseEnter()
    {
        if(placeable && currentUnit == null) highlight.SetActive(true);
    }
    private void OnMouseExit()
    {
        if(placeable) highlight.SetActive(false);
    }
}