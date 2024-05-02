using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider SFXSlider;
    private static VolumeSettings instance;

    private void Awake()
    {
        // Verificar si ya existe una instancia de VolumeSettings
        if (instance == null)
        {
            // Si no hay ninguna instancia, establecer esta como la instancia
            instance = this;
            DontDestroyOnLoad(gameObject); // Mantener este objeto entre las escenas
        }
        else
        {
            // Si ya hay una instancia, destruir este objeto
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("MusicVolumen"))
        {
            LoadVolumen();
        }
        else
        {
            SetMusicVolumen();
            SetSFXVolumen();
        }
    }
    public void SetMusicVolumen()
    {
        float volumen = musicSlider.value;
        myMixer.SetFloat("Music", Mathf.Log10(volumen)*20);
        PlayerPrefs.SetFloat("MusicVoumen", volumen);
    }
    public void SetSFXVolumen()
    {
        float volumen = SFXSlider.value;
        myMixer.SetFloat("SFX", Mathf.Log10(volumen) * 20);
        PlayerPrefs.SetFloat("SFXVoumen", volumen);
    }
    public void LoadVolumen()
    {
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolumen");
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolumen");
        SetMusicVolumen();
        SetSFXVolumen();
    }
    
}
