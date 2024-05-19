using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
   

    public GameObject winPanel;
    public GameObject gameOverPanel;
  


    // Test
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
            LifeManager.Instance.LoseLife();

        if (Input.GetKeyDown(KeyCode.I))
            LifeManager.Instance.AddLife();

        if (Input.GetKeyDown(KeyCode.S))
            Time.timeScale = 0.1f;

        if (Input.GetKeyDown(KeyCode.R))
            Time.timeScale = 1;
    }

    public void Awake()
    {
        Instance = this;
        LifeManager.Instance.InitializeLife();
    }

    public void RestartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void CheckWin()
    {
        if (LevelGenerator.Instance.bricksCount == BrickController.totalBrokenBricks)
            GameWin();
    }
    public void GameWin() 
    {
        winPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }

    

}
