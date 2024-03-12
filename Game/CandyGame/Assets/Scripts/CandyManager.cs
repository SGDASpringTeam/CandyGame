using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class CandyManager : MonoBehaviour
{
    private Dictionary<PrimaryType, int> primaryMaterials;
    private Dictionary<SecondaryType, int> secondaryMaterials;

    [SerializeField] private TextMeshProUGUI materialsAmount;

    private void Start()
    {
        primaryMaterials = new Dictionary<PrimaryType, int>();
        secondaryMaterials = new Dictionary<SecondaryType, int>();

        primaryMaterials[PrimaryType.Sour] = 10;
        primaryMaterials[PrimaryType.Spicy] = 10;
        primaryMaterials[PrimaryType.Sweet] = 10;

        secondaryMaterials[SecondaryType.Gummy] = 10;
        secondaryMaterials[SecondaryType.Soft] = 10;
        secondaryMaterials[SecondaryType.Hard] = 10;

        UpdateMaterials();
    }

    public void SelectUnit(GameObject unit)
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        Instantiate(unit, mousePosition, Quaternion.identity);
    }

    public void ObtainMaterials(PrimaryType type1, SecondaryType type2, int materials1, int materials2)
    {
        primaryMaterials[type1] += materials1;
        secondaryMaterials[type2] += materials2;
        UpdateMaterials();
    }
    private void UpdateMaterials()
    {
        materialsAmount.text = "";
        foreach (var pair in primaryMaterials)
        {
            materialsAmount.text += pair.Key + " - " + pair.Value + "\n";
        }
        materialsAmount.text += "\n";
        foreach (var pair in secondaryMaterials)
        {
            materialsAmount.text += pair.Key + " - " + pair.Value + "\n";
        }
    }
}