using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

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
            PointerEventData eventData = new(EventSystem.current);
            eventData.position = Input.mousePosition;
            List<RaycastResult> results = new();
            EventSystem.current.RaycastAll(eventData, results);

            if (results.Count > 0)
            {
                foreach (RaycastResult result in results)
                {
                    if (result.gameObject.CompareTag("Mold"))
                    {
                        UnitButton unitButton = result.gameObject.GetComponent<UnitButton>();
                        if (unitButton != null)
                        {
                            unitButton.FillMold(candyType);
                            break;
                        }
                    }
                }
            }

            Destroy(gameObject);
        }
    }
}