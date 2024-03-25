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
 
    private void Start()
    {
       playerTransform = FindObjectOfType<PlayerMovement>().transform;

      

    }

    private void Update()
    {
        var dist = Vector3.Distance(transform.position, playerTransform.position);

       // Debug.Log(dist);
       // Debug.Log(awarenessRadius);

        if (dist < awarenessRadius)
        {
           // Debug.Log("gone aggro");
            isAggro = true;
            Ogmat = GetComponent<SkinnedMeshRenderer>().material;
            GetComponent<SkinnedMeshRenderer>().material = AggroMat;
        }

        else
        {
            isAggro = false;
            GetComponent<SkinnedMeshRenderer>().material = Ogmat;
        }

        transform.position = gameObject.GetComponentInParent<Transform>().position;
    }

    
}
