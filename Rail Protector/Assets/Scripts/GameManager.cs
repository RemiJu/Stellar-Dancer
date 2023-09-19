using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameObject("GameManager").AddComponent<GameManager>();
                //instance = this;

            }
            return _instance;
        }
        
    }
    public GameObject playerShip;
    public GameObject spawnPoint;

    public Animator transAnim;

    public int score = 0;
    public float timer = 0.0f;
    public int deathCount = 0;

    public float totalTime;
    public int totalScore;
    public int totalDeath;

    public bool timing = true;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        
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

    public void Respawn()
    {
        if(spawnPoint == null)
        {
            spawnPoint = GameObject.FindWithTag("Spawn");
        }
        Instantiate(playerShip, spawnPoint.transform.position, spawnPoint.transform.rotation);
    }

    IEnumerator LoadLevel()
    {
        transAnim.SetTrigger("End");
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        transAnim.SetTrigger("Start");
    }
}
