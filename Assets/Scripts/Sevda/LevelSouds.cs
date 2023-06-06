using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSouds : MonoBehaviour
{
    private static readonly string MusicPref = "MusicPref";
    private float musicFloat, soundEffectsFloat;
    public AudioSource[] soundEffectsAudio;

    private void Awake()
    {
        LevelSoundSettings();
    }

    private void LevelSoundSettings()
    {
        musicFloat = PlayerPrefs.GetFloat(MusicPref);

        for (int i = 0; i < soundEffectsAudio.Length; i++)
        {
            soundEffectsAudio[i].volume = musicFloat;
        }
    }
}
