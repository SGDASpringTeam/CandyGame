using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Object scene;

    public void PlayButton()
    {
        SceneManager.LoadScene(scene.name);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
