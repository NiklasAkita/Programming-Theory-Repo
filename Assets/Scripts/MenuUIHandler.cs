using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] GameObject gameOverPanel;
    void Update()
    {
        if (GameManager.Instance && gameOverPanel && GameManager.Instance.isGameOver)
        {
            gameOverPanel.SetActive(true);
        };
    }

    public void StartGame()
    {
        SceneHandler.Instance.StartGame();
    }

    public void ExitGame()
    {
        SceneHandler.Instance.ExitGame();
    }

    public void GoToMenu()
    {
        SceneHandler.Instance.GoToMenu();
    }

}
