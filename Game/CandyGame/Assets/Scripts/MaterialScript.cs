using UnityEngine;

public class MaterialScript : MonoBehaviour
{
    public CandyType candyType;

    private void Update()
    {
        MoveMaterial();
    }

    private void MoveMaterial()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        transform.position = mousePosition;

        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<UnitButton>() != null)
                {
                    UnitButton unitButton = hit.collider.GetComponent<UnitButton>();
                    unitButton.FillMold(candyType);
                }
            }
            Destroy(this.gameObject);
        }
    }
}