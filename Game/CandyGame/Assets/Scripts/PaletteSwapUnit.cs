using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaletteSwapUnit : MonoBehaviour
{
    public Texture LookupTexture;

    Material _mat;
    // Start is called before the first frame update
    void Start()
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
