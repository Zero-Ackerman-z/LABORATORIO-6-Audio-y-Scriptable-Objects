using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "SoundEffectData", menuName = "Audio/SoundEffectData", order = 1)]

public class SoundEffectData : ScriptableObject
{
    [System.Serializable]
    public class SoundEffectEntry
    {
        public string effectName;
        public AudioClip effectClip;
    }

    public SoundEffectEntry[] soundEffectEntries;
}
