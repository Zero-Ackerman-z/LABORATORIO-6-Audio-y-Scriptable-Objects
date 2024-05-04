using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "BackgroundMusicData", menuName = "Audio/BackgroundMusicData", order = 1)]

public class BackgroundMusicData : ScriptableObject
{
    [System.Serializable]
    public class BackgroundMusicEntry
    {
        public string musicTitle;
        public AudioClip musicClip;
    }
    public BackgroundMusicEntry musicEntry;

}