using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    public GameObject levelSelect;
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public Image NewLevelText;

    public void MenuClick()
    {
        StartCoroutine(MainMenu());
    }

    public void LevelOneClick()
    {
        StartCoroutine(LevelOne());
    }

    public void LevelSelectClick()
    {
        StartCoroutine(LevelSelect());
    }

    public void OptionsClick()
    {
        StartCoroutine(OptionsMenu());
    }

    public void EndClick()
    {
        StartCoroutine(EndGame());
    }

    private void Start()
    {
<<<<<<< Updated upstream
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
=======
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
>>>>>>> Stashed changes

        if (SceneManager.GetActiveScene().name == "EndScene")
        {
            StartCoroutine(NewLevelFadeIn(1.5f, NewLevelText));
        }


    }














    public IEnumerator NewLevelFadeIn(float t, Image i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
        yield return new WaitForSeconds(1.5f);
        i.gameObject.SetActive(false);
    }

    public IEnumerator LevelSelect()
    {
        yield return new WaitForSeconds(0.5f);
        mainMenu.SetActive(false);
        levelSelect.SetActive(true);
    }

    public IEnumerator LevelOne()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Scene 1");
    }

    public IEnumerator OptionsMenu()
    {
        yield return new WaitForSeconds(0.5f);
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public IEnumerator MainMenu()
    {
        yield return new WaitForSeconds(0.5f);
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public IEnumerator EndGame()
    {
        yield return new WaitForSeconds(0.5f);
        Application.Quit();
    }
}
