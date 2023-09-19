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

    //public Canvas finalResults;
    //public Canvas scoreTrack;

    public int score = 0;
    public float timer = 0.0f;
    public int deathCount = 0;

    //public bool spawnersInScene;

    public float totalTime;
    public int totalScore;
    public int totalDeath;

    public bool timing = true;
    private GameObject ship;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this); 
    }

    private void Awake()
    {
        timing = true;
        DontDestroyOnLoad(this);
        
        
        //scoreTrack = GameObject.Find("Score Tracker").GetComponent<Canvas>();
        //finalResults = GameObject.Find("Final Score").GetComponent<Canvas>();
        //scoreTrack.enabled = true;
        //finalResults.enabled = false;
    }

    /*public void PauseMenu()
    {

    }*/
    public void FinalScore()
    {
        Time.timeScale = 0f;
        timing = false;
        //scoreTrack.enabled = false;
        //finalResults.enabled = true;
        totalScore = score;
        totalDeath = deathCount;
        totalTime = timer;
    }

    public void NextLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        //StartCoroutine(LoadLevel());
    }

    void Update()
    {
        //scoreTrack = GameObject.Find("Score Tracker").GetComponent<Canvas>();
        //finalResults = GameObject.Find("Final Score").GetComponent<Canvas>();

        timer = timer += 1 * Time.deltaTime;

        if (GameObject.FindWithTag("Player") == null)
        {
            Debug.Log("Canadia");
            Respawn();
        }
    }

    public void Respawn()
    {
        //Instantiate(playerShip, spawnPoint.transform.position, spawnPoint.transform.rotation);
        playerShip.transform.position = spawnPoint.transform.position;
    }

    IEnumerator LoadLevel()
    {
        transAnim.SetTrigger("End");
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        transAnim.SetTrigger("Start");
    }
}
