using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddEnemy : MonoBehaviour
{
    public EnemyManager enemyManager;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("enter");

        if (other.isTrigger)
        {
            return;
        }

        Enemy enemy = other.transform.GetComponent<Enemy>();

        if (enemy)
        {
            Debug.Log("add");
            enemyManager.AddEnemy(enemy);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("exit");

        if (other.isTrigger)
        {
            return;
        }

        else
        {
            Enemy enemy = other.transform.GetComponent<Enemy>();

            if (enemy)
            {
                Debug.Log("remove");
                enemyManager.RemoveEnemy(enemy);
            }
        }
        
    }
}
