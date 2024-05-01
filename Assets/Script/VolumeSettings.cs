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
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
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
    private void LoadVolumen()
    {
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolumen");
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolumen");
        SetMusicVolumen();
        SetSFXVolumen();
    }
    // Start is called before the first frame update
    private void Start()
    {
        if(PlayerPrefs.HasKey("MusicVolumen"))
        {
            LoadVolumen();
        }
        else
        {
            SetMusicVolumen();
            SetSFXVolumen();
        }
    }
}
