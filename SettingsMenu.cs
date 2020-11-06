using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public TMP_Dropdown qualityDropDown;
    public TMP_Dropdown resDropdown;

    Resolution[] resolutions;



    public float masterVolume;



    private void Start()
    {
        QualitySettings.SetQualityLevel(2);
        qualityDropDown.value = 2;

        resolutions = Screen.resolutions;
        resDropdown.ClearOptions();

        List<string> resOptions = new List<string>();
        int currentResIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            resOptions.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResIndex = i;
            }
        }
        resDropdown.AddOptions(resOptions);
        resDropdown.value = currentResIndex;
        resDropdown.RefreshShownValue();
    }


    public void SetMasterVolume(float volume)
    {
        masterVolume = volume;
        audioMixer.SetFloat("MasterVolume", masterVolume);
    }

    public void ToggleMusic(bool isOn)
    {
        if (isOn == true)
        {
            audioMixer.SetFloat("MusicVolume", 0f);
        }
        else if (isOn == false)
        {
            audioMixer.SetFloat("MusicVolume", -80f);
        }
    }
    public void ToggleFX(bool isOn)
    {
        if (isOn == true)
        {
            audioMixer.SetFloat("FXvolume", 0f);
        }
        else if (isOn == false)
        {
            audioMixer.SetFloat("FXvolume", -80f);
        }
    }

    public void SetGraphics(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
    
    public void SetResolution(int resIndex)
    {
        Resolution resolution = resolutions[resIndex];
        Screen.SetResolution(resolution.width, resolution.height,Screen.fullScreen);
    }
}
