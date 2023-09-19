using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Animator transAnim;

    public int score = 0;
    public float timer = 0.0f;
    public int deathCount = 0;

    public float totalTime;
    public int totalScore;
    public int totalDeath;

    public bool timing = true;

    // Start is called before the first frame update
    void Awake()
    {
       if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
       else
        {
            Destroy(gameObject);
        }
    }

    public void NextLevel()
    {
        StartCoroutine(LoadLevel());
    }

    private void Update()
    {
        if(timing == true)
        {
            timer = timer + Time.deltaTime;
        } else
        {
            totalTime = timer;
        }
        
    }

    IEnumerator LoadLevel()
    {
        transAnim.SetTrigger("End");
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        transAnim.SetTrigger("Start");
    }
}
