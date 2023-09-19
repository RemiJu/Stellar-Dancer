using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int healthPoints;
    public int enemyValue;
    public int damageValue;

    // Update is called once per frame
    void Update()
    {
        if(healthPoints <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void EnemyPattern()
    {

    }

    public void BossPattern()
    {

    }
}
