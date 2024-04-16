using System.Collections;
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

        if (health > maxHealth)
        {
            health = maxHealth;
        }

        if (armor > maxArmor)
        {
            armor = maxArmor;
        }
    }

    public void GiveHealth(int amount, GameObject pickup)
    {
        if (health < maxHealth)
        {
            print($" Current health = {health}");
            health += amount;
            print($" New health = {health}");
            Destroy(pickup);
        }
    }

    public void GiveArmor(int amount, GameObject pickup)
    {
        if (armor < maxArmor)
        {
            print($" Current armor = {armor}");
            armor += amount;
            print($" New armor = {armor}");
            Destroy(pickup);
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
