using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpdateText : MonoBehaviour
{
    private PlayerHealth playerHealth;
    private Gun gun; 
    private EnemyManager enemyManager;


    public TMP_Text AmmoText;
    public TMP_Text HealthText;
    public TMP_Text ArmorText;
    public TMP_Text WeaponText;


    public TMP_Text goalText;
    public TMP_Text endText;

    // Start is called before the first frame update
    void Start()
    {
        
        playerHealth = FindObjectOfType<PlayerHealth>().GetComponent<PlayerHealth>();
        gun = FindObjectOfType<Gun>().GetComponent<Gun>();
        enemyManager = FindObjectOfType<EnemyManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(PublicVars.sfxVolume);
        Debug.Log(PublicVars.musicVolume);
        HealthText.text = $"{playerHealth.health}/{playerHealth.maxHealth}";
        ArmorText.text = $"{playerHealth.armor}/{playerHealth.maxArmor}";

        AmmoText.text = $"{gun.currentAmmo}/{gun.maxAmmo}";
        WeaponText.text = $"{gun.weapon}";

        goalText.text = $"Defeat All Enemies: {enemyManager.currentenemies}/{enemyManager.totalenemies}";


        if (enemyManager.currentenemies <= 0 && gun.hasShot)
        {
            StartCoroutine(EndLevel());
        }

        if (PublicVars.endLevelOne && Input.GetKeyDown(KeyCode.Q))
        {
           
            SceneManager.LoadScene("MenuScene");
        }

    }

    public IEnumerator EndLevel()
    {
        goalText.gameObject.SetActive(false);
        endText.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        PublicVars.endLevelOne = true;
    }
}
