using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Animator transAnim;
    // Start is called before the first frame update
    void Awake()
    {
       
    }

    public void NextLevel()
    {
        StartCoroutine(LoadLevel());
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LoadLevel()
    {
        transAnim.SetTrigger("End");
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        transAnim.SetTrigger("Start");
    }
}
