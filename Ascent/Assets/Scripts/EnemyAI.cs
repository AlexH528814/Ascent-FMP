using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public EnemyAwareness enemyAwareness;
    public Transform playerTransform;
    public NavMeshAgent enemyAgent;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = FindObjectOfType<PlayerMovement>().transform;
       // enemyAwareness = GetComponent<EnemyAwareness>();
        enemyAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyAwareness.isAggro)
        {
       
            enemyAgent.SetDestination(playerTransform.position);
       
        }
       
    }
}