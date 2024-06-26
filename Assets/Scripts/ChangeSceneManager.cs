using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneManager : MonoBehaviour
{
   public void GoToLevels()
    {
        SceneManager.LoadSceneAsync("Levels");
    }

    public void Play()
    {
        SceneManager.LoadSceneAsync("Game Scene");
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadSceneAsync("Main Menu");
    }
}
