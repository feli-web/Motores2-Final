using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuReset : MonoBehaviour
{
    public void ResetButton()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
    public void MenuButton()
    {
        SceneManager.LoadScene(0);
    }
}
