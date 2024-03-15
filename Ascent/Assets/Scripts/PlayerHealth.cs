using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using Scene = UnityEngine.SceneManagement.Scene;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    public int health;

    public int maxArmor;
    public int armor;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        armor = maxArmor;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            int dam = 30;
            DamagePlayer(dam);
            Debug.Log($"Player damaged by {dam}");
        }

       
    }

    public void DamagePlayer(int damage)
    {
        if (armor > 0)
        {
            if (armor >= damage)
            {
                armor -= damage;
            }

            else if (armor < damage)
            {
                int remdam = damage - armor;
                armor = 0;
                health -= remdam;
            }
        }

        else
                health -= damage;

        if (health <= 0)
        {
            Debug.Log("Player died");
            StartCoroutine(Die());
        }
    }

    IEnumerator Die()
    {
        this.GetComponent<PlayerMovement>().enabled = false;
        yield return new WaitForSeconds(1f);
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
