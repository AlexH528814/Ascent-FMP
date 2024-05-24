using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource backgroundMusic;

    // Start is called before the first frame update
    void Start()
    {
        backgroundMusic.volume = PublicVars.musicVolume;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
