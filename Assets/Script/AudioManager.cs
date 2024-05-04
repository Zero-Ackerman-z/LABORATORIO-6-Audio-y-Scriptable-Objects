using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private List<BackgroundMusicData> backgroundMusicDatas;
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
            DontDestroyOnLoad(gameObject); // Para que el objeto AudioManager no se destruya al cargar una nueva escena

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
        if (backgroundMusicDatas == null || backgroundMusicDatas.Count == 0)
        {
            Debug.LogError("BackgroundMusicDatas list is not set or empty!");
            return;
        }
        previousBackgroundMusicTitle = GetCurrentBackgroundMusicTitle();

        for (int i = 0; i < backgroundMusicDatas.Count; i++)
        {
            BackgroundMusicData bgMusicData = backgroundMusicDatas[i];
            // Verificar si el objeto bgMusicData es nulo y si tiene una entrada de música válida
            if (bgMusicData != null && bgMusicData.musicEntry != null && bgMusicData.musicEntry.musicTitle == musicTitle)
            {
                // Asignar el clip de audio al AudioSource
                backgroundMusicAudioSource.clip = bgMusicData.musicEntry.musicClip;

                // Reproducir en bucle la música de fondo
                backgroundMusicAudioSource.loop = true;
                backgroundMusicAudioSource.Play();
                return;
            }
        }

        Debug.LogWarning("Music with title " + musicTitle + " not found in any BackgroundMusicData!");
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
        // Asegurarse de que backgroundMusicDatas esté inicializado
        if (backgroundMusicDatas == null)
        {
            backgroundMusicDatas = new List<BackgroundMusicData>();
        }

        // Agregar el objeto data a la lista
        backgroundMusicDatas.Add(data);
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
    public void ResumePreviousSoundEffect()
    {
        // Llama al AudioManager para reproducir el efecto de sonido anterior
        PlaySoundEffect(previousSoundEffectName);
    }
    public void StopSoundEffect(string effectName)
    {
// Comprueba si el AudioSource de efectos de sonido es nulo
    if (soundEffectAudioSource == null)
    {
        Debug.LogWarning("Sound effect AudioSource is not assigned!");
        return;
    }

    // Detiene la reproducción del efecto de sonido si coincide con el nombre proporcionado
    if (soundEffectAudioSource.isPlaying && soundEffectAudioSource.clip != null && soundEffectAudioSource.clip.name == effectName)
    {
        soundEffectAudioSource.Stop();
    }
    }
}

