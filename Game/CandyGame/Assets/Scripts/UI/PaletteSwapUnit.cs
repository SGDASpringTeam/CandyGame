using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PaletteSwapUnit : MonoBehaviour
{
    public Texture[] LookupTexture;
    public int textureID = 0;

    public PlayerUnit playerUnit;
    public bool paletteSet = false;

    Material _mat;
    // SHOULD NOT BE IN UPDATE FOR PERFORMANCE REASONS
    void Update()
    {
        if (playerUnit.deployed && !paletteSet)
        {
            SetPalette();
            Shader shader = Shader.Find("Hidden/PaletteSwapLookup");
            if (_mat == null)
                _mat = new Material(shader);

            _mat.SetTexture("_PaletteTex", LookupTexture[textureID]);
            //Graphics.Blit(src, dst, _mat);

            SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            spriteRenderer.material = _mat;
            paletteSet = true;
        }
    }

    public void SetPalette()
    {
        if (playerUnit.type1 == PrimaryType.Spicy && playerUnit.type2 == SecondaryType.Hard)
        {
            //Peppermint
            textureID = 0;
        }

        else if (playerUnit.type1 == PrimaryType.Sweet && playerUnit.type2 == SecondaryType.Hard)
        {
            //RockCandy
            textureID = 1;
        }

        else if (playerUnit.type1 == PrimaryType.Sour && playerUnit.type2 == SecondaryType.Hard)
        {
            //HardCandy
            textureID = 2;
        }

        else if (playerUnit.type1 == PrimaryType.Spicy && playerUnit.type2 == SecondaryType.Soft)
        {
            //Licorice
            textureID = 3;
        }

        else if (playerUnit.type1 == PrimaryType.Sweet && playerUnit.type2 == SecondaryType.Soft)
        {
            //Chocolate
            textureID = 4;
        }

        else if (playerUnit.type1 == PrimaryType.Sour && playerUnit.type2 == SecondaryType.Soft)
        {
            //SourTaffy
            textureID = 5;
        }

        else if (playerUnit.type1 == PrimaryType.Spicy && playerUnit.type2 == SecondaryType.Gummy)
        {
            //Cinnimon
            textureID = 6;
        }

        else if (playerUnit.type1 == PrimaryType.Sweet && playerUnit.type2 == SecondaryType.Gummy)
        {
            //Bubblegum
            textureID = 7;
        }

        else if (playerUnit.type1 == PrimaryType.Sour && playerUnit.type2 == SecondaryType.Gummy)
        {
            //Gumdrop
            textureID = 8;
        }
    }
}
