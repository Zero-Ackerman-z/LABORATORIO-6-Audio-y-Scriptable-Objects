using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private BackgroundMusicData backgroundMusicData;
    [SerializeField] private AudioSource backgroundMusicAudioSource; // AudioSource para la música de fondo
    [SerializeField] private string previousBackgroundMusicTitle; // Título de la música de fondo anterior
    [SerializeField] private SoundEffectData soundEffectData; // Referencia al scriptable object de datos de efectos de sonido
    [SerializeField] private AudioSource soundEffectAudioSource; // AudioSource para la música de fondo
    [SerializeField] private string previousSoundEffectName;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        // Obtener el AudioSource de la música de fondo si no se ha configurado
        if (backgroundMusicAudioSource == null)
        {
            backgroundMusicAudioSource = GetComponent<AudioSource>();
        }

        if (soundEffectAudioSource == null)
        {
            soundEffectAudioSource = gameObject.AddComponent<AudioSource>();
        }
    }
    public void PlayBackgroundMusic(string musicTitle)
    {
        if (backgroundMusicData == null)
        {
            Debug.LogError("BackgroundMusicData is not set!");
            return;
        }

        for (int i = 0; i < backgroundMusicData.musicEntries.Length; i++)
        {
            BackgroundMusicData.BackgroundMusicEntry entry = backgroundMusicData.musicEntries[i];
            if (entry.musicTitle == musicTitle)
            {
                previousBackgroundMusicTitle = backgroundMusicAudioSource.clip != null ? backgroundMusicAudioSource.clip.name : "";

                backgroundMusicAudioSource.clip = entry.musicClip;
                backgroundMusicAudioSource.Play();
                return;
            }
        }

        Debug.LogWarning("Music with title " + musicTitle + " not found in BackgroundMusicData!");
    }
    public void PauseBackgroundMusic()
    {
        backgroundMusicAudioSource.Pause();
    }
    public void ResumeBackgroundMusic()
    {
        backgroundMusicAudioSource.UnPause();
    }
    public void SetBackgroundMusicData(BackgroundMusicData data)
    {
        backgroundMusicData = data;
    }
    public string GetCurrentBackgroundMusicTitle()
    {
        // Devuelve el título de la música de fondo actual
        return backgroundMusicAudioSource.clip != null ? backgroundMusicAudioSource.clip.name : "";
    }
    public void ResumePreviousBackgroundMusic()
    {
        // Llamar al AudioManager para reanudar la música de fondo anterior
        PlayBackgroundMusic(previousBackgroundMusicTitle);
    }
    public void PlaySoundEffect(string effectName)
    {
        if (soundEffectData == null)
        {
            Debug.LogError("SoundEffectData is not set!");
            return;
        }

        for (int i = 0; i < soundEffectData.soundEffectEntries.Length; i++)
        {
            SoundEffectData.SoundEffectEntry entry = soundEffectData.soundEffectEntries[i];
            if (entry.effectName == effectName)
            {
                previousSoundEffectName = soundEffectAudioSource.clip != null ? soundEffectAudioSource.clip.name : "";
                soundEffectAudioSource.clip = entry.effectClip;
                soundEffectAudioSource.Play();
                return;
            }
        }
    }
    public void SetsoundEffectData(SoundEffectData data)
    {
        soundEffectData = data;
    }
    public string GetsoundEffectTitle()
    {
        // Devuelve el título de la música de fondo actual
        return soundEffectAudioSource.clip != null ? soundEffectAudioSource.clip.name : "";
    }

}

