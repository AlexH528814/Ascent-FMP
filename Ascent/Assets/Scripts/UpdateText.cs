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



    private float fpsUpdateTime = 0.5f; // Update FPS every 0.5 seconds
    private float timeSinceLastUpdate;
    private int frameCount;
    private float fps;

    // Start is called before the first frame update
    void Start()
    {
        timeSinceLastUpdate = 0f;
        frameCount = 0;
        fps = 0f;

        playerHealth = FindObjectOfType<PlayerHealth>().GetComponent<PlayerHealth>();
        gun = FindObjectOfType<Gun>().GetComponent<Gun>();
        enemyManager = FindObjectOfType<EnemyManager>();
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastUpdate += Time.deltaTime;
        frameCount++;

        if (timeSinceLastUpdate >= fpsUpdateTime)
        {
            fps = frameCount / timeSinceLastUpdate;
            timeSinceLastUpdate = 0f;
            frameCount = 0;
        }

        Debug.Log(PublicVars.sfxVolume);
        Debug.Log(PublicVars.musicVolume);
        HealthText.text = $"{playerHealth.health}/{playerHealth.maxHealth}";
        ArmorText.text = $"{playerHealth.armor}/{playerHealth.maxArmor}";

        AmmoText.text = $"{gun.currentAmmo}/{gun.maxAmmo}";
         WeaponText.text = $"{gun.weapon}";
       // WeaponText.text = fps.ToString();
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
