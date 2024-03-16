using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PaletteSwapUnit : MonoBehaviour
{
    public Texture LookupTexture;

    Material _mat;
    // SHOULD NOT BE IN UPDATE FOR PERFORMANCE REASONS
    void Update()
    {
        Shader shader = Shader.Find("Hidden/PaletteSwapLookup");
        if (_mat == null)
            _mat = new Material(shader);

        _mat.SetTexture("_PaletteTex", LookupTexture);
        //Graphics.Blit(src, dst, _mat);

        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.material = _mat; 
    }
}
