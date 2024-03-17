using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.VFX;

public class MenuButtons : MonoBehaviour
{
    public void LoadSceneButton(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}