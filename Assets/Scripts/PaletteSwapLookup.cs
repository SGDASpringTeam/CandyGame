using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class PaletteSwapLookup : MonoBehaviour
{
	public int currentPalette = 0;
	public Texture[] LookupTextures;

	Material _mat;

	void OnEnable()
	{
		Shader shader = Shader.Find("Hidden/PaletteSwapLookup");
		if (_mat == null)
			_mat = new Material(shader);
    }

	void OnDisable()
	{
		if (_mat != null)
			DestroyImmediate(_mat);
	}

	void OnRenderImage(RenderTexture src, RenderTexture dst)
	{
		_mat.SetTexture("_PaletteTex", LookupTextures[currentPalette]);
		Graphics.Blit(src, dst,  _mat);
	}

	public void NextPalette() {
		if (currentPalette == LookupTextures.Length - 1) {
			currentPalette = 0;
		} else {
			currentPalette++;
		}
	}

	public void PreviousPalette() {
		if (currentPalette == 0) {
			currentPalette = LookupTextures.Length - 1;
		} else {
			currentPalette--;
		}
	}
}
