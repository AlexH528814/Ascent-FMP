using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public bool isHealth;
    public bool isArmor;
    public bool isAmmo;

    public int amount;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (isHealth)
            {
                Debug.Log(other.GetComponent<PlayerHealth>().health);
                other.GetComponent<PlayerHealth>().GiveHealth(amount, gameObject);
                Debug.Log(other.GetComponent<PlayerHealth>().health);
            }

            if (isArmor)
            {
                Debug.Log(other.GetComponent<PlayerHealth>().armor);
                other.GetComponent<PlayerHealth>().GiveArmor(amount, gameObject);
                Debug.Log(other.GetComponent<PlayerHealth>().armor);
            }

            if  (isAmmo)
            {
                other.GetComponentInChildren<Gun>().GiveAmmo(amount, gameObject);
            }
        }
    }
}
