using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class CandyManager : MonoBehaviour
{
    public int startingAmount;

    [SerializeField] private GameObject[] buttons;
    [SerializeField] private TextMeshProUGUI[] amounts;

    private readonly Dictionary<string, int> materials = new();

    private void Start()
    {
        materials.Add("Peppermint", startingAmount);
        materials.Add("RockCandy", startingAmount);
        materials.Add("HardCandy", startingAmount);
        materials.Add("Licorice", startingAmount);
        materials.Add("Chocolate", startingAmount);
        materials.Add("SourTaffy", startingAmount);
        materials.Add("CinnamonJelly", startingAmount);
        materials.Add("Bubblegum", startingAmount);
        materials.Add("Gumdrop", startingAmount);
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
        }
    }
    public void UseMaterial(CandyType candyType)
    {
        string materialType = candyType.ToString();
        materials[materialType]--;
    }

    public void SelectUnit(UnitButton unit)
    {
        if(unit.isFilled)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;

            GameObject newUnit = unit.UnitPrefab;
            newUnit.GetComponent<PlayerUnit>().SetTyping(unit.filledCandy);

            Instantiate(newUnit, mousePosition, Quaternion.identity);
        }
    }
    public void DeployUnit(string unitName)
    {
        foreach (GameObject unitButton in buttons)
        {
            if (unitButton.name == unitName)
            {
                unitButton.GetComponent<UnitButton>().BreakMold();
                break;
            }
        }
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