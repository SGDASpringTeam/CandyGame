using UnityEngine;

public class GridTile : MonoBehaviour
{
    [SerializeField] private GameObject highlight;

    private void OnMouseEnter()
    {
        highlight.SetActive(true);
    }
    private void OnMouseExit()
    {
        highlight.SetActive(false);
    }
}