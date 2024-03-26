using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateText : MonoBehaviour
{
    private PlayerHealth playerHealth;
    private Gun gun; 

    public TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>().GetComponent<PlayerHealth>();
        gun = FindObjectOfType<Gun>().GetComponent<Gun>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = $"Health = {playerHealth.health}/{playerHealth.maxHealth}\n" +
            $"Armor = {playerHealth.armor}/{playerHealth.maxArmor}\n" +
            $"Ammo = {gun.currentAmmo}/{gun.maxAmmo}";
    }
}
