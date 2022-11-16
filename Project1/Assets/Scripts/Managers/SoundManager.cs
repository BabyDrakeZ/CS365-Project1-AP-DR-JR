using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    Manager manager;
    public AudioSource[] allSources;
    public int masterVolume = 100;
    public int fadeOut = 1;
    // Start is called before the first frame update
    void Start()
    {
        manager = GetComponent<Manager>();
    }

    float volume()
    {
        return (masterVolume % 100) / 100f;
    }

    // Update is called once per frame
    void Update()
    {
        allSources = FindObjectsOfType<AudioSource>();
        if (manager.gameOver)
        {
            masterVolume = Mathf.Max(0, masterVolume-fadeOut);
            foreach (AudioSource source in allSources) {
                source.volume = Mathf.Max(0, source.volume - (fadeOut%100)/100f);
            }
        }
    }
}
