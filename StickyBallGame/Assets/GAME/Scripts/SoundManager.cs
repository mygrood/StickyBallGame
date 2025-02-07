using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource effectSource;

    [SerializeField] private AudioClip menuMusic;
    [SerializeField] private AudioClip gameMusic;
    [SerializeField] private AudioClip gameOverMusic;

    [SerializeField] private AudioClip[] effectSounds;

    private bool isSoundOn;
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
        if (!PlayerPrefs.HasKey("SoundOn"))
        {
            PlayerPrefs.SetInt("SoundOn", 1);
            isSoundOn = true;
            PlayerPrefs.Save();
        }
        else
        {
            isSoundOn = PlayerPrefs.GetInt("SoundOn") == 1 ? true : false;
        }
        UpdateAudioSettings();
       
    }

    public void SetGameMusic()
    {
        musicSource.clip = gameMusic;
        musicSource.Play();
    }

    public void SetMenuMusic()
    {
        musicSource.clip = menuMusic;
        musicSource.Play();
    }

    public void SetGameOverMusic()
    {
        musicSource.clip = gameOverMusic;
        musicSource.Play();
    }

    public void PlaySoundEffect(int index)
    {
        if (index >= 0 && index < effectSounds.Length)
        {
            effectSource.PlayOneShot(effectSounds[index]);
        }
    }
    
    public void ToggleSound()
    {
        isSoundOn = !isSoundOn;
        PlayerPrefs.SetInt("SoundOn", isSoundOn ? 1 : 0);
        UpdateAudioSettings();
    }

    private void UpdateAudioSettings()
    {
        musicSource.mute = !isSoundOn;
        effectSource.mute = !isSoundOn;
    }
    
}