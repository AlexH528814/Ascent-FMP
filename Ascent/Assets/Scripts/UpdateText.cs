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

    public bool endGame;

    public TMP_Text text;

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
        text.text = $"Health = {playerHealth.health}/{playerHealth.maxHealth}\n" +
            $"Armor = {playerHealth.armor}/{playerHealth.maxArmor}\n" +
            $"Ammo = {gun.currentAmmo}/{gun.maxAmmo}\n" + 
            $"Enemies remaining: {enemyManager.totalenemies}";

        Debug.Log(enemyManager.totalenemies);

        if (enemyManager.totalenemies <= 0 && gun.hasShot)
        {
            StartCoroutine(EndLevel());
        }

        if (endGame && Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene("EndScene");
        }

    }

    public IEnumerator EndLevel()
    {
        endText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        endGame = true;
    }
}
