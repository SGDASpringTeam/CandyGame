using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class CandyManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] amounts;
    private readonly Dictionary<string, int> materials = new();

    private void Start()
    {
        materials.Add("Peppermint", 1);
        materials.Add("RockCandy", 1);
        materials.Add("HardCandy", 1);
        materials.Add("Licorice", 1);
        materials.Add("Chocolate", 1);
        materials.Add("SourTaffy", 1);
        materials.Add("CinnamonJelly", 1);
        materials.Add("Bubblegum", 1);
        materials.Add("Gumdrop", 1);
    }
    private void Update()
    {
        UpdateMaterials();
    }

    public void SelectMaterial(GameObject material)
    {
        string materialType = material.GetComponent<MaterialScript>().candyType.ToString();
        if(materials[materialType] > 0)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            Instantiate(material, mousePosition, Quaternion.identity);
            materials[materialType]--;
        }
    }
    public void SelectUnit(GameObject unit)
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        Instantiate(unit, mousePosition, Quaternion.identity);
    }

    public void ObtainMaterials(PrimaryType type1, SecondaryType type2)
    {
        switch (type1)
        {
            case PrimaryType.Spicy:
                switch (type2)
                {
                    case SecondaryType.Hard:
                        materials["Peppermint"]++;
                        break;
                    case SecondaryType.Soft:
                        materials["Licorice"]++;
                        break;
                    case SecondaryType.Gummy:
                        materials["CinnamonJelly"]++;
                        break;
                }
                break;
            case PrimaryType.Sweet:
                switch (type2)
                {
                    case SecondaryType.Hard:
                        materials["RockCandy"]++;
                        break;
                    case SecondaryType.Soft:
                        materials["Chocolate"]++;
                        break;
                    case SecondaryType.Gummy:
                        materials["Bubblegum"]++;
                        break;
                }
                break;
            case PrimaryType.Sour:
                switch (type2)
                {
                    case SecondaryType.Hard:
                        materials["HardCandy"]++;
                        break;
                    case SecondaryType.Soft:
                        materials["SourTaffy"]++;
                        break;
                    case SecondaryType.Gummy:
                        materials["Gumdrop"]++;
                        break;
                }
                break;
        }
    }

    private void UpdateMaterials()
    {
        int amountIndex = 0;
        foreach (KeyValuePair<string, int> material in materials)
        {
            int materialAmount = material.Value;
            amounts[amountIndex].text = "x " + materialAmount;
            amountIndex++;
        }
    }
}