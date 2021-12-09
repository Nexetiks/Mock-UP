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

    [SerializeField]
   private Sprite SoundOn;
    [SerializeField]
    private Sprite SoundOff;
    [SerializeField]

      private Sprite MusicOn;
     [SerializeField]
     private Sprite MusicOff;
     [SerializeField]
     private Image soundBtn;
     [SerializeField]
     private Image audioBtn;



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
        if (soundEffect.mute == true)
        {
            soundBtn.sprite = SoundOff;
            soundEffect.mute = false;
        }
        else
        {
            soundBtn.sprite = SoundOn;
            soundEffect.mute = true;
        }

    }
    public void StopMusic()
    {
      
        backgroundMusic.Stop();

    }

    public void StopBackgroundMusic()
    {
        if (backgroundMusic.isPlaying) { backgroundMusic.Stop(); audioBtn.sprite = MusicOn; }
        else { backgroundMusic.Play(); audioBtn.sprite = MusicOff; }

        }

    public void ChangeVolume()
    {
        backgroundMusic.volume= slider.value;
    }


}
