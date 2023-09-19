using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class ResultsDisplay : MonoBehaviour
{
    public TextMeshProUGUI finalScore;
    public TextMeshProUGUI finalDeath;
    public TextMeshProUGUI finalTime;
    // Start is called before the first frame update
    void Start()
    {
        finalDeath.text = "Final Death Count: " + 0;
        finalScore.text = "Final Score: " + 0;
        finalTime.text = "Final Time: " + 0;
    }

    // Update is called once per frame
    void Update()
    {
        finalDeath.text = "Final Death Count: " + GameManager.instance.totalDeath;
        finalScore.text = "Final Score: " + + GameManager.instance.totalScore;
        finalTime.text = "Final Time: " + GameManager.instance.totalTime;
    }

    public void BackToMenu()
    {
        Time.timeScale = 1f;
        GameManager.instance.deathCount = 0;
        GameManager.instance.timer = 0.0f;
        GameManager.instance.score = 0;
        SceneManager.LoadScene("Main Menu");
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        GameManager.instance.deathCount = 0;
        GameManager.instance.timer = 0.0f;
        GameManager.instance.score = 0;
        SceneManager.LoadScene("Route 1-1");
        GameManager.instance.timing = true;
    }
    public void EndGame()
    {
        Application.Quit();
    }

}
