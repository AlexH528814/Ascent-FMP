using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    public GameObject levelSelect;
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject deathScreen;
    public TMP_Text NewLevelText;
    public Slider sens;
    public Slider sfxvolume;
    public Slider musicvolume;

    public Button[] lockedLevels;

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
        sens.value = PublicVars.mouseSens;
        musicvolume.value = PublicVars.musicVolume;
        sfxvolume.value = PublicVars.sfxVolume;
        Debug.Log(PublicVars.mouseSens);


        if (Cursor.lockState == CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }


        if (PublicVars.endLevelOne && !PublicVars.LevelTwoUnlocked)
        {
            StartCoroutine(NewLevelFadeIn(1.5f, NewLevelText));
            PublicVars.LevelTwoUnlocked = true;
        }

        if (PublicVars.playerDied)
        {
            mainMenu.SetActive(false);
            deathScreen.SetActive(true);
        }

    }

    public void Update()
    {
        if (PublicVars.LevelTwoUnlocked)
            lockedLevels[0].interactable = true;

        Debug.Log(PublicVars.sfxVolume);
        Debug.Log(PublicVars.musicVolume);
        // Debug.Log(PublicVars.mouseSens);
    }

    public void SensSlider()
    {
        PublicVars.mouseSens = sens.value;
    }

    public void MusicSlider()
    {
        PublicVars.musicVolume = musicvolume.value;
    }

    public void SFXSlider()
    {
        PublicVars.sfxVolume = sfxvolume.value;
    }












    public IEnumerator NewLevelFadeIn(float t, TMP_Text i)
    {
        i.gameObject.SetActive(true);
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
       // yield return new WaitForSeconds(1.5f);
        StartCoroutine(NewLevelFadeOut(t, i));
        // i.gameObject.SetActive(false);
    }

    public IEnumerator NewLevelFadeOut(float t, TMP_Text i)
    {
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
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
