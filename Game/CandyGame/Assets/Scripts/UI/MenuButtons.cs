using UnityEngine;
using UnityEngine.SceneManagement;

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