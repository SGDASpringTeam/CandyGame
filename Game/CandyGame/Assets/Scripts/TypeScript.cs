using UnityEngine;

// This script is meant to hold the different Types
// Read below to see type matchups, and what two types make up each material

public enum PrimaryType
{
    Spicy,
    Sour,
    Sweet,
}
public enum SecondaryType
{
    Hard,
    Soft,
    Gummy,
}

public enum CandyType
{
    None,
    Peppermint,
    RockCandy,
    HardCandy,
    Licorice,
    Chocolate,
    SourTaffy,
    CinnamonJelly,
    Bubblegum,
    Gumdrop
}

public class TypeScript : MonoBehaviour
{
    /*
     * Spicy > Sour
     * Sweet > Spicy
     * Sour > Sweet
     * 
     * Hard > Soft
     * Soft > Gummy
     * Gummy > Hard
    */

    /*
     * Spicy & Hard = Peppermint
     * Spicy & Soft = Licorice
     * Spicy & Gummy = Cinnamon Jelly
     * 
     * Sweet & Hard = Rock Candy
     * Sweet & Soft = Chocolate
     * Sweet & Gummy = Bubblegum
     * 
     * Sour & Hard = Hard Candy
     * Sour & Soft = Sour Taffy
     * Sour & Gummy = Gumdrop
    */
}