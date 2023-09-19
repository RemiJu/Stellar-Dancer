using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float bulletSpeed;
    public float botTop;
    public int enemyType = 0;

    public GameObject bullet;

    // Start is called before the first frame update
    void Awake()
    {

    }

    void EnemyBeHaviour()
    {
        if(enemyType == 1)
        {
            transform.Translate(Vector3.down * bulletSpeed * Time.deltaTime);
        }

        if(enemyType == 2)
        {
            transform.Translate(Vector3.up * -bulletSpeed * Time.deltaTime);
        }
        
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("ROADA ROLLA WRYYYYYYYYYYYYYYYYY");
        if (gameObject.tag == "EnemyBullet" && collision.gameObject.tag == "Player")
        {
            GameManager.instance.deathCount += 1;
            //Destroy(collision.gameObject);
            GameManager.instance.Respawn();

        }

        if (gameObject.tag == "HeroBullet" && (collision.gameObject.tag == "Boss" 
            || collision.gameObject.tag == "Enemy A" 
            || collision.gameObject.tag == "Enemy B"))
        {
            collision.gameObject.GetComponent<EnemyScript>().healthPoints -= 1;

            if (collision.gameObject.GetComponent<EnemyScript>().healthPoints <= 0)
            {
                GameManager.instance.score += collision.gameObject.GetComponent<EnemyScript>().enemyValue;
            }
            
            if (collision.gameObject.GetComponent<EnemyScript>().healthPoints > 0)
            {
                Debug.Log("lolswwwwwwww");
                GameManager.instance.score += collision.gameObject.GetComponent<EnemyScript>().damageValue;
                Debug.Log("ROADA ROLLA WRYYYYYYYYYYYYYYYYY");
            }
        }

        Destroy(gameObject);
    }

    void HeroBehaviour()
    {
        transform.Translate(Vector3.back * -bulletSpeed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "EnemyBullet")
        {
            EnemyBeHaviour();
        }
        
        if (gameObject.tag == "HeroBullet")
        {
            HeroBehaviour();
        }

        if(bullet.transform.position.y >= botTop || bullet.transform.position.y <= -botTop)
        {
            Destroy(gameObject);
        }
    }
}
