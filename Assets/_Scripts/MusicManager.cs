using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField]
    public AudioSource backgroundMusic;
    private AudioSource clipMusic;

    [SerializeField]
    public List<string> soundName;
    [SerializeField]
    public List<AudioSource> soundSource;

    public void PlaySound(string audioName)
    {
        for (int i = 0; i < soundSource.Count; i++)
        {
            if (soundName[i] == audioName) { clipMusic = soundSource[i]; clipMusic.Play(); return; }
        }

    }

    public void StopBackgroundMusic()
    {


    }


}
