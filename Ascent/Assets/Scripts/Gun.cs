using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.PackageManager;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float range = 20f;
    public float verticalRange = 20f;
    public float fireRate = 1f;
    public float damage = 2f;
    public float gunShotRadius = 20f;
    public float currentAmmo;
    public float maxAmmo = 25;

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
        gunTrigger.center = new Vector3(0, 0, range * 0.5f);
        currentAmmo = maxAmmo;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > cooldown && currentAmmo > 0)
        {
          //  Debug.Log("shoot");
            Fire();
            currentAmmo--;
        }


    }

    void Fire()
    {
        Collider[] enemyColliders;
        enemyColliders = Physics.OverlapSphere(transform.position, gunShotRadius, enemyLayerMask);

        foreach (var enemyCollider in enemyColliders)
        {
          //  Debug.Log("Aggro");
            enemyCollider.GetComponent<EnemyAwareness>().isAggro = true;
        }
     
       // Debug.Log("shot");
        foreach (var enemy in enemyManager.enemiesInTrigger)
        {
           // Debug.Log("enemy.name");

            var dir = enemy.transform.position - transform.position;
            //Debug.Log(dir);
            RaycastHit hit;
            if (Physics.Raycast(transform.position, dir, out hit, range * 1.5f, raycastLayerMask))
            {
               // Debug.Log("ray works");
                //Debug.Log(hit.transform);
               // Debug.Log(enemy.transform);
                if (hit.transform == enemy.transform)
                {
                   // Debug.Log("hit");

                    if (enemyManager.enemiesInTrigger.Contains(enemy))
                    {
                        enemyManager.RemoveEnemy(enemy);
                    }
                    enemy.TakeDamage(damage);              
                }

                
            }
        }
        // Debug.Log("shoot");
        Debug.Log(cooldown);
        cooldown = Time.time + fireRate;
        Debug.Log(cooldown);
    }

    public void GiveAmmo(int amount, GameObject pickup)
    {
        if (amount > maxAmmo)
        {
            print($" Current armor = {currentAmmo}");
            currentAmmo += amount;
            print($" New armor = {currentAmmo}");
            Destroy(pickup);
        }
    }

}
