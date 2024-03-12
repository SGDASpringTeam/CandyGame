using UnityEngine;

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
}