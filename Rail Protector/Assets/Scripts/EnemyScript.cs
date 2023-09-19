using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject bullet;
    public int healthPoints;
    public int enemyValue;
    public int damageValue;
    public int enemyType;

    public float timeSpeed;
    public Transform shootSpawn;

    public float enemySpeed;

    public float shootTime;
    public float initialShootTime;

    public float screenLength;
    public float screenWidth;

    //public Transform startPos;
    //public Transform endPos;
    //private Vector3 targetPos;

    private void Awake()
    {
        //targetPos = new Vector3(startPos.position.x, startPos.position.y, startPos.position.z);
    }
    // Update is called once per frame
    void Update()
    {
        shootTime -= timeSpeed * Time.deltaTime;

        if(healthPoints <= 0)
        {
            Destroy(gameObject);
        }
        if(enemyType == 1)
        {
            EnemyPattern();
        } else
            if (enemyType == 2)
        {
            BossPattern();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.instance.deathCount += 1;
            //Destroy(collision.gameObject);
            GameManager.instance.Respawn();

        }
    }

    public void EnemyPattern()
    {
        if(gameObject.tag == "Enemy A")
        {
            if (gameObject.transform.position.y >= screenLength || gameObject.transform.position.y <= -screenLength)
            {
                Destroy(gameObject);
            }
            transform.Translate(Vector3.down * enemySpeed * Time.deltaTime);
        }
        
        if(gameObject.tag == "Enemy B")
        {
            if (gameObject.transform.position.x >= screenWidth || gameObject.transform.position.x <= -screenWidth)
            {
                Destroy(gameObject);
            }

            transform.Translate(Vector3.right * enemySpeed * Time.deltaTime);

            if (shootTime <= 0)
            {
                shootTime = initialShootTime;
                Instantiate(bullet, shootSpawn.transform.position, shootSpawn.transform.rotation);
            }

        }
    }

    public void BossPattern()
    {
        /**Vector3 currentPos = transform.position;
        Rigidbody boss = gameObject.GetComponent<Rigidbody>();

        if (currentPos == new Vector3(startPos.position.x, startPos.position.y, startPos.position.z))
        {
            targetPos = new Vector3(endPos.position.x, endPos.position.y, endPos.position.z);
        } else if(currentPos == new Vector3(endPos.position.x, endPos.position.y, endPos.position.z))
        {
            targetPos = new Vector3(startPos.position.x, startPos.position.y, startPos.position.z);
        }

        Vector3 targetDirection = (currentPos - targetPos).normalized;
        boss.MovePosition(currentPos + targetDirection * Time.deltaTime);**/

        if (shootTime <= 0)
        {
            shootTime = initialShootTime;
            Instantiate(bullet, shootSpawn.transform.position, shootSpawn.transform.rotation);
        }
    }
}
