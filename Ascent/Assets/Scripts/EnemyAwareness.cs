using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAwareness : MonoBehaviour
{
    public float awarenessRadius;
    public Transform playerTransform;
    public Material AggroMat;
    public Material Ogmat;
    public bool isAggro;

    public float attackRange;

    EnemyDamage enemyDamage;
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
       playerTransform = FindObjectOfType<PlayerMovement>().transform;
        enemyDamage= GetComponent<EnemyDamage>();
    }

    private void Update()
    {
        var dist = Vector3.Distance(transform.position, playerTransform.position);

       //Debug.Log(dist);
       //Debug.Log(awarenessRadius);

        

        if (dist < awarenessRadius)
        {
           //Debug.Log("gone aggro");
            isAggro = true;
            GetComponent<SkinnedMeshRenderer>().material = AggroMat;
            if (dist < attackRange)
            {
                anim.SetBool("isWalking", false);
                anim.SetBool("isInAttackRange", true);
                enemyDamage.damagingPlayer = true;
            }
            if (dist > attackRange)
            {
                anim.SetBool("isWalking", true);
                anim.SetBool("isInAttackRange", false);
                enemyDamage.damagingPlayer = false;
            }
        }

        else
        {
            isAggro = false;
            GetComponent<SkinnedMeshRenderer>().material = Ogmat;
            anim.SetBool("isWalking", false);
        }

        transform.position = gameObject.GetComponentInParent<Transform>().position;
    }
}
