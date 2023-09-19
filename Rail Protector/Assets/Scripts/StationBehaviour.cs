using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationBehaviour : MonoBehaviour
{
    public int stationType;
    public int stationSpeed;
    public GameObject scoreTrack;
    

    void Awake()
    {
        scoreTrack = GameObject.Find("Score Tracker");
        
    }
    void OnTriggerEnter(Collider other)
    {
        if(stationType == 1)
        {
            if (other.gameObject.tag == "Player")
            {
                print("ROAD ROLLA");
                GameManager.instance.NextLevel();
            }
        }
        if (stationType == 2)
        {
            if (other.gameObject.tag == "Player")
            {
                GameManager.instance.FinalScore();
                scoreTrack.SetActive(false);
            }
        }

    }

    void Update()
    {
            transform.Translate(Vector3.down * stationSpeed * Time.deltaTime);
    }
}
