using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyManager enemyManager;
    public float enemyHealth = 2f;

    public GameObject gunHitEffect;
 
    public GameObject EnemyParent;

    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
       
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth <= 0)
        {
            
            Destroy(EnemyParent);
        }
    }

    public void TakeDamage(float damage)
    {
        enemyManager.totalenemies--;
        Instantiate(gunHitEffect, transform.position, Quaternion.identity);
        enemyHealth -= damage;
        enemyManager.totalenemies--;

    }
}
