using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MusicManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource backgroundMusic;
    [SerializeField]
    private AudioSource soundEffect;
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private List<string> soundName;
    [SerializeField]
    private List<AudioClip> soundSource;

    public void PlaySound(string audioName)
    {
        for (int i = 0; i < soundSource.Count; i++)
        {
         
            if (soundName[i] == audioName) {
                soundEffect.clip = soundSource[i];
                
               soundEffect.Play();
                
                
                return; 
            }
        }

    }

    public void StopSoundEffect()
    {
        soundEffect.mute = true;

    }
    public void StopMusic()
    {
        backgroundMusic.Stop();

    }

    public void StopBackgroundMusic()
    {
        if(backgroundMusic.isPlaying) backgroundMusic.Stop();
        else backgroundMusic.Play();

    }

    public void ChangeVolume()
    {
        backgroundMusic.volume= slider.value;
    }


}
