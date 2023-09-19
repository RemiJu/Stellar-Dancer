using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float screenWidth;
    public float velocity;
    public GameObject ship;
    public GameObject bullet;
    public Transform bulletSpawn;

    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("a") && ship.transform.position.x >= -screenWidth)
        {
           transform.Translate(Vector3.left * -velocity * Time.deltaTime);
        } 

        else

        if (Input.GetKey("d") && ship.transform.position.x <= screenWidth)
        {
            transform.Translate(Vector3.right * -velocity * Time.deltaTime);
        }

        if (Input.GetKeyDown("space"))
        {
            BulletShoot();
        }
    }

    void BulletShoot()
    {
        Instantiate(bullet, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Finish")
        {
            GameManager.instance.FinalScore();
        }
    }
}
