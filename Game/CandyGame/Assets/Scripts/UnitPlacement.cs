using UnityEngine;

public class UnitPlacement : MonoBehaviour
{
    public void SelectUnit(GameObject unit)
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        Instantiate(unit, mousePosition, Quaternion.identity);
    }
}