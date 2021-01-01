using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        // Gets the build index of the current active scene
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        // Load scene at the next index
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadStartScreen()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameStatus>().ResetGame();
    }
    public void Quit()
    {
        Application.Quit();
    }
}
