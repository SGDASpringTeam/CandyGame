using UnityEngine;

public class PlayerUnit : MonoBehaviour
{
    public bool deployed;

    private void Start()
    {
        deployed = false;
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
                        transform.position = hit.collider.gameObject.transform.position;
                        return;
                    }
                }
            }
            Destroy(this.gameObject);
        }
    }
}