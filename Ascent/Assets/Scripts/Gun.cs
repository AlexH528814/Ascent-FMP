using System.Collections;
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
    public bool hasShot;

    private float cooldown;

    private BoxCollider gunTrigger;
    public EnemyManager enemyManager;

    public LayerMask enemyLayerMask;
    public LayerMask raycastLayerMask;

    public GameObject gunShotEffect;
    public Transform gunShotTransform;

    public Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        gunTrigger = GetComponent<BoxCollider>();
        gunTrigger.size = new Vector3(1, verticalRange, range);
        gunTrigger.center = new Vector3(0, 0, range * 0.5f);
        currentAmmo = maxAmmo;

    }

    // Update is called once per frame
    void Update()
    {
        if (currentAmmo > maxAmmo)
        {
            currentAmmo = maxAmmo;
        }

        if (Input.GetMouseButtonDown(0) && Time.time > cooldown && currentAmmo > 0)
        {
            hasShot = true;
            //Debug.Log("shoot");
            currentAmmo--;
            StartCoroutine(AnimateGunShot());
            Instantiate(gunShotEffect, gunShotTransform.position, Quaternion.identity, gunShotTransform);
            Fire();
        }
    }

    void Fire()
    {
        Collider[] enemyColliders;
        enemyColliders = Physics.OverlapSphere(transform.position, gunShotRadius, enemyLayerMask);

        foreach (var enemyCollider in enemyColliders)
        {
          //Debug.Log("Aggro");
            enemyCollider.GetComponent<EnemyAwareness>().isAggro = true;
        }
            RaycastHit hit;
        
            if (Physics.Raycast(transform.position, transform.forward, out hit, range * 1.5f, raycastLayerMask))
            {
                Enemy enemy = hit.transform.GetComponent<Enemy>();

               //Debug.Log("ray works");
                Debug.Log(hit.transform);
                Debug.Log(hit.transform.name);
                Debug.Log(enemy.transform);
                if (hit.transform == enemy.transform)
                {
                    enemy.TakeDamage(damage); 
                    if (enemy.enemyHealth <= 0)
                    {
                        enemyManager.totalenemies--;
                    }
                }  
            }
        //}
        //Debug.Log("shoot");
        Debug.Log($"cooldown is {cooldown}");
        cooldown = Time.time + fireRate;
        Debug.Log($"cooldown is {cooldown}");
    }

    public void GiveAmmo(int amount, GameObject pickup)
    {
        if (currentAmmo < maxAmmo)
        {
            print($" Current ammo = {currentAmmo}");
            currentAmmo += amount;
            print($" New ammo = {currentAmmo}");
            Destroy(pickup);
        }
    }

    public IEnumerator AnimateGunShot()
    {
        anim.Play("GunRecoil");
        yield return new WaitForSeconds(0.35f);
        anim.Play("GunIdle");
    }
}
