using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPaletteSwap : MonoBehaviour
{
    public Texture[] LookupTexture;
    public int textureID = 0;

    public EnemyUnit enemyUnit;
    public bool paletteSet = false;

    Material _mat;
    // SHOULD NOT BE IN UPDATE FOR PERFORMANCE REASONS
    void Update()
    {
        if (!paletteSet)
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
        if (enemyUnit.type1 == PrimaryType.Spicy && enemyUnit.type2 == SecondaryType.Hard)
        {
            //Peppermint
            textureID = 0;
        }

        else if (enemyUnit.type1 == PrimaryType.Sweet && enemyUnit.type2 == SecondaryType.Hard)
        {
            //RockCandy
            textureID = 1;
        }

        else if (enemyUnit.type1 == PrimaryType.Sour && enemyUnit.type2 == SecondaryType.Hard)
        {
            //HardCandy
            textureID = 2;
        }

        else if (enemyUnit.type1 == PrimaryType.Spicy && enemyUnit.type2 == SecondaryType.Soft)
        {
            //Licorice
            textureID = 3;
        }

        else if (enemyUnit.type1 == PrimaryType.Sweet && enemyUnit.type2 == SecondaryType.Soft)
        {
            //Chocolate
            textureID = 4;
        }

        else if (enemyUnit.type1 == PrimaryType.Sour && enemyUnit.type2 == SecondaryType.Soft)
        {
            //SourTaffy
            textureID = 5;
        }

        else if (enemyUnit.type1 == PrimaryType.Spicy && enemyUnit.type2 == SecondaryType.Gummy)
        {
            //Cinnimon
            textureID = 6;
        }

        else if (enemyUnit.type1 == PrimaryType.Sweet && enemyUnit.type2 == SecondaryType.Gummy)
        {
            //Bubblegum
            textureID = 7;
        }

        else if (enemyUnit.type1 == PrimaryType.Sour && enemyUnit.type2 == SecondaryType.Gummy)
        {
            //Gumdrop
            textureID = 8;
        }
    }
}
