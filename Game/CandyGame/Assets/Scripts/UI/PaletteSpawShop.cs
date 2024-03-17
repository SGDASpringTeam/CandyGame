using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[ExecuteInEditMode]
public class PaletteSwapShop : MonoBehaviour
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

        Image image = gameObject.GetComponent<Image>();
        image.material = _mat;
    }
}

