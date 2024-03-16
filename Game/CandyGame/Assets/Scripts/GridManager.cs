using UnityEngine;

public class GridManager : MonoBehaviour
{
    // How many Lanes are on the Grid, and How many Spaces are in each Lane
    public int lanes;
    public int spaces;

    public GameObject[] playerGrid; // Holds Each Lane
    public GridTile[,] gridData; // Holds Data for Each Tile

    // Populates gridData based on grid layout in game scene
    private void Start()
    {
        gridData = new GridTile[lanes, spaces];
        for(int l = 0; l < lanes; l++)
        {
            for(int s = 0; s < spaces; s++)
            {
                gridData[l, s] = playerGrid[l].transform.GetChild(s).gameObject.GetComponent<GridTile>();
            }
        }
    }

    // Continuously checks if a player unit is in the "Waiting Space", and if Lane can be shifted
    private void Update()
    {
        for(int l = 0; l < lanes; l++)
        {
            GridTile tile = gridData[l, 0];
            if (tile.currentUnit != null && tile.currentUnit.GetComponent<PlayerUnit>() != null)
            {
                ShiftLane(l);
            }
        }
    }

    // Moves All Units in the Lane to the Right by One Space
    private void ShiftLane(int lane)
    {
        GridTile nextAvailableTile = null;
        int nextSpace = 0;
        for(int s = 1; s < spaces; s++)
        {
            if(gridData[lane,s].currentUnit == null)
            {
                nextAvailableTile = gridData[lane, s];
                nextSpace = s;
                break;
            }
        }

        if (nextAvailableTile != null)
        {
            for (int s = nextSpace - 1; s >= 0; s--)
            {
                GameObject unit = gridData[lane, s].currentUnit;
                unit.transform.position = gridData[lane, s + 1].gameObject.transform.position;

                gridData[lane, s].currentUnit = null;
                gridData[lane, s + 1].currentUnit = unit;
            }
        }
    }
}