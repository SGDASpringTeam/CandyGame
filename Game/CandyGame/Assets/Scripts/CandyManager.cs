using UnityEngine;
using TMPro;

public class CandyManager : MonoBehaviour
{
    [Header("Materials")]
    public int Peppermint = 1;
    public int RockCandy = 1;
    public int HardCandy = 1;
    public int Licorice = 1;
    public int Chocolate = 1;
    public int SourTaffy = 1;
    public int CinnamonJelly = 1;
    public int Bubblegum = 1;
    public int Gumdrop = 1;

    [SerializeField] private TextMeshProUGUI materialsAmount;

    private void Update()
    {
        UpdateMaterials();
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
                        Peppermint++;
                        break;
                    case SecondaryType.Soft:
                        Licorice++;
                        break;
                    case SecondaryType.Gummy:
                        CinnamonJelly++;
                        break;
                }
                break;
            case PrimaryType.Sweet:
                switch (type2)
                {
                    case SecondaryType.Hard:
                        RockCandy++;
                        break;
                    case SecondaryType.Soft:
                        Chocolate++;
                        break;
                    case SecondaryType.Gummy:
                        Bubblegum++;
                        break;
                }
                break;
            case PrimaryType.Sour:
                switch (type2)
                {
                    case SecondaryType.Hard:
                        HardCandy++;
                        break;
                    case SecondaryType.Soft:
                        SourTaffy++;
                        break;
                    case SecondaryType.Gummy:
                        Gumdrop++;
                        break;
                }
                break;
        }
    }
    private void UpdateMaterials()
    {
        materialsAmount.text = "" +

            "Peppermint x" + Peppermint + "\n" +
            "Rock Candy x" + RockCandy + "\n" +
            "Hard Candy x" + HardCandy + "\n" +
            "Licorice x" + Licorice + "\n" +
            "Chocolate x" + Chocolate + "\n" +
            "Sour Taffy x" + SourTaffy + "\n" +
            "Cinnamon Jelly x" + CinnamonJelly + "\n" +
            "Bubblegum x" + Bubblegum + "\n" +
            "Gumdrop x" + Gumdrop;
    }
}