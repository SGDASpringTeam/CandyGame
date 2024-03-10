using UnityEngine;

public class GridTile : MonoBehaviour
{
    public GameObject currentUnit;

    [SerializeField] private GameObject highlight;

    public void PlaceUnit(GameObject placedUnit)
    {
        currentUnit = placedUnit;
    }

    private void OnMouseEnter()
    {
        highlight.SetActive(true);
    }
    private void OnMouseExit()
    {
        highlight.SetActive(false);
    }
}