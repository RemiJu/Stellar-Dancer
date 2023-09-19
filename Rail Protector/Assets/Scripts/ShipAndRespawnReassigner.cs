using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipAndRespawnReassigner : MonoBehaviour
{
    public GameObject newPlayer;
    public GameObject newSpawnPoint;

    public GameObject finalScore;

    // Start is called before the first frame update
    void Start()
    {
        newPlayer = GameObject.FindWithTag("Player");
        newSpawnPoint = GameObject.FindWithTag("Respawn");

        finalScore = GameObject.FindGameObjectWithTag("Finish");
        finalScore.gameObject.GetComponent<Canvas>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        GameManager.instance.playerShip = newPlayer;
        GameManager.instance.spawnPoint = newSpawnPoint;

        if(GameManager.instance.timing == false)
        {
            finalScore.gameObject.GetComponent<Canvas>().enabled = true;
        }
    }
}
