using UnityEngine;
using UnityEngine.UI;

public class UnitButton : MonoBehaviour
{
    public bool isFilled;
    public CandyType filledCandy;

    private Button unitButton;

    private void Start()
    {
        isFilled = false;

        unitButton = GetComponent<Button>();
        unitButton.interactable = false;
    }

    public void FillMold(CandyType candyType)
    {
        filledCandy = candyType;
        isFilled = true;
        unitButton.interactable = true;
    }
}