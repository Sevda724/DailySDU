using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionMenu : MonoBehaviour
{
    //public Dropdown resolutionDropdown;
    public Dropdown qualityDropdown;
    public Toggle fullscreenToggle;
    //Resolution[] resolutions;

    void Start()
    {
        int currentResolutionIndex = 0;

        //resolutionDropdown.ClearOptions();
        /* List<string> options = new List<string>();
         resolutions = Screen.resolutions;

         for (int i = 0; i < resolutions.Length; i++)
         {
             string option = resolutions[i].width + "x" + resolutions[i].height + " " + resolutions[i].refreshRate + "Hz";
             options.Add(option);
             if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
                 currentResolutionIndex = i;
         }

         resolutionDropdown.AddOptions(options);
         resolutionDropdown.RefreshShownValue();*/
        LoadSettings(currentResolutionIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    /* public void SetResolution(int resolutionIndex)
     {
         Resolution resolution = resolutions[resolutionIndex];
         Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
     }*/

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    /*public void ExitSettings()
    {
        SceneManager.LoadScene("Level");
    }*/

    public void SaveSettings()
    {
        PlayerPrefs.SetInt("QualitySettingPreference", qualityDropdown.value);
        PlayerPrefs.SetInt("FullscreenPreference", System.Convert.ToInt32(fullscreenToggle.isOn));
        // PlayerPrefs.SetInt("ResolutionPreference", resolutionDropdown.value);
    }

    public void LoadSettings(int currentResolutionIndex)
    {
        if (PlayerPrefs.HasKey("QualitySettingPreference"))
            qualityDropdown.value = PlayerPrefs.GetInt("QualitySettingPreference");
        else
            qualityDropdown.value = 3;

        /*if (PlayerPrefs.HasKey("ResolutionPreference"))
            resolutionDropdown.value = PlayerPrefs.GetInt("ResolutionPreference");
        else
            resolutionDropdown.value = currentResolutionIndex;*/

        if (PlayerPrefs.HasKey("FullscreenPreference"))
            fullscreenToggle.isOn = System.Convert.ToBoolean(PlayerPrefs.GetInt("FullscreenPreference"));
        else
            fullscreenToggle.isOn = true;
    }




    /*public AudioMixer audioMixer;

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", Mathf.Log10(volume) * 20);

    }

    public void setQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void sound()
    {
        AudioListener.pause = !AudioListener.pause;
    }*/
}
