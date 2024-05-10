using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{
    public int totalenemies;
    public int currentenemies;

    public void Start()
    {
        totalenemies = 0;

        Enemy[] enemies = FindObjectsOfType<Enemy>();

        foreach (Enemy enemy in enemies) { totalenemies++; }

        currentenemies = totalenemies;
    }

    private void Update()
    {
       //Debug.Log(totalenemies);
    }

}
