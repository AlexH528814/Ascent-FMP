using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAwareness : MonoBehaviour
{
    public Material AggroMat;
    public bool isAggro;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            isAggro = true;
            GetComponent<SkinnedMeshRenderer>().material = AggroMat;
        }
    }
}
