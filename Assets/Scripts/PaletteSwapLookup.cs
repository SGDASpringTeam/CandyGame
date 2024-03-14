using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class PaletteSwapLookup : MonoBehaviour {
    private int MyCurrentPalette;
    public Texture[] LookupTextures;
    public static PaletteSwapLookup instance;

    Material _mat;

    void OnEnable() {
        Shader shader = Shader.Find("Hidden/PaletteSwapLookup");
        if (_mat == null)
        {
            _mat = new Material(shader);
        }

        MyCurrentPalette = Manager.currentPalette;
    }

    void OnDisable() {
        if (_mat != null)
            DestroyImmediate(_mat);
    }

    void OnRenderImage(RenderTexture src, RenderTexture dst) {
        _mat.SetTexture("_PaletteTex", LookupTextures[Manager.currentPalette]);
        Graphics.Blit(src, dst, _mat);
    }

    public void NextPalette() {
        if (Manager.currentPalette == LookupTextures.Length - 1) {
            Manager.currentPalette = 0;
        } else {
            Manager.currentPalette++;
        }
    }

    public void PreviousPalette() {
        if (Manager.currentPalette == 0) {
            Manager.currentPalette = LookupTextures.Length - 1;
        } else {
            Manager.currentPalette--;
        }
    }
}
