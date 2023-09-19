using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{  
    public void LoadScene (string sceneName)
    {
        GameManager.instance.timing = true;
        SceneManager.LoadScene(sceneName);
    }

    public void StartLevel()
    {
        GameManager.instance.NextLevel();
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void Retry()
    {
        //ResetManager();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void RetryAll()
    {
        ResetManager();
        SceneManager.LoadScene("Route 1-1");
    }
    public void ResetManager()
    {
        GameManager.instance.score = 0;
        GameManager.instance.timer = 0;
        GameManager.instance.deathCount = 0;
    }
}

