using UnityEngine;
using UnityEngine.UI;

public class UnitButton : MonoBehaviour
{
    // Which Unit this Mold Represents
    public GameObject UnitPrefab;

    // Used to Check How the UI Button will be interacted with
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

    // Called when the player drags and drops a material into the Mold
    // Player can now drag and drop the unit represented by this Mold
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

    // Called when the player drags and drops a Unit from the Mold to the Grid
    // Resets the UI Button to be "empty"
    public void BreakMold()
    {
        filledCandy = CandyType.None;
        isFilled = false;
        unitButton.interactable = false;
    }
}