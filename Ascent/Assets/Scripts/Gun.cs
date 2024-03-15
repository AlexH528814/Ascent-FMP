using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float range = 20f;
    public float verticalRange = 20f;
    public float fireRate = 1f;
    public float damage = 2f;
    public float gunShotRadius = 20f;

    private float cooldown;

    private BoxCollider gunTrigger;
    public EnemyManager enemyManager;

    public LayerMask enemyLayerMask;
    public LayerMask raycastLayerMask;
    

    // Start is called before the first frame update
    void Start()
    {
        gunTrigger = GetComponent<BoxCollider>();
        gunTrigger.size = new Vector3(1, verticalRange, range);
       // gunTrigger.center = new Vector3(0, 0, range * 0.5f);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > cooldown)
        {
            Debug.Log("shoot");
            Fire();
        }
    }

    void Fire()
    {
        Collider[] enemyColliders;
        enemyColliders = Physics.OverlapSphere(transform.position, gunShotRadius, enemyLayerMask);

        foreach (var enemyCollider in enemyColliders)
        {
            Debug.Log("Aggro");
            enemyCollider.GetComponent<EnemyAwareness>().isAggro = true;
        }
     
        Debug.Log("shot");
        foreach (var enemy in enemyManager.enemiesInTrigger)
        {
            Debug.Log("enemy.name");

            var dir = enemy.transform.position - transform.position;

            RaycastHit hit;
            if (Physics.Raycast(transform.position, dir, out hit, range * 1.5f, raycastLayerMask))
            {
                if (hit.transform == enemy.transform)
                {
                    Debug.Log("hit");
                    enemyManager.RemoveEnemy(enemy);
                    enemy.TakeDamage(damage);
                }
            }
        }
       // Debug.Log("shoot");
        cooldown = Time.time + fireRate;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("enter");
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
        Enemy enemy = other.transform.GetComponent<Enemy>();

        if (enemy)
        {
            Debug.Log("remove");
            enemyManager.RemoveEnemy(enemy);
        }
    }
}
