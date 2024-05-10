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

    public GameObject AmmoDrop;
    public GameObject HealthDrop;
    public GameObject ArmorDrop;
    public Transform itemdropPos;


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
        float dropChance = Random.Range(1, 100);
        enemyManager.totalenemies--;
        Instantiate(gunHitEffect, transform.position, Quaternion.identity);

        if (dropChance <= 10)
        {
            Instantiate(AmmoDrop, itemdropPos.position, Quaternion.identity);
        }       

        else if (dropChance > 10 && dropChance <= 15) 
        {
            Instantiate(HealthDrop, itemdropPos.position, Quaternion.identity);
        }

        else if (dropChance > 15 && dropChance <= 20)
        {
            Instantiate(ArmorDrop, itemdropPos.position, Quaternion.identity);
        }


        enemyHealth -= damage;
        enemyManager.totalenemies--;

    }
}
