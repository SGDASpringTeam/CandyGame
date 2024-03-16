using UnityEngine;
using UnityEngine.UI;

public class UnitButton : MonoBehaviour
{
    public GameObject UnitPrefab;

    public bool isFilled;
    public CandyType filledCandy;

    private Button unitButton;
    private CandyManager candyManager;

    private void Start()
    {
        isFilled = false;

        unitButton = GetComponent<Button>();
        unitButton.interactable = false;

        candyManager = GetComponentInParent<CandyManager>();
    }

    public void FillMold(CandyType candyType)
    {
        if(!isFilled)
        {
            filledCandy = candyType;

            isFilled = true;
            unitButton.interactable = true;

            candyManager.UseMaterial(candyType);
        }
    }

    public void BreakMold()
    {
        filledCandy = CandyType.None;
        isFilled = false;
        unitButton.interactable = false;
    }
}