using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public bool damagingPlayer;
    private PlayerHealth playerhealth;

    public int damage = 10;
    public float damagecooldown;

    public float damagecounter;

    // Start is called before the first frame update
    void Start()
    {
        damagecounter = damagecooldown;
        playerhealth = FindObjectOfType<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (damagingPlayer)
        {
            if (damagecounter > damagecooldown) 
            {
                playerhealth.DamagePlayer(damage);

                damagecounter = 0f;
            }
            damagecounter += Time.deltaTime;
        }

      /*  else
        {
            damagecounter = 0f;
        }*/
    }
}
