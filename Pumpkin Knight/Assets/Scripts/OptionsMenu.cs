using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    Resolution[] resolutions;
    public TMP_Dropdown resolutionsDropwdown;
    public AudioMixer audioMixer;
    public Slider MasterVolumeSlider;
    public Toggle FulscreenToggle;
    public TMP_Dropdown GraphicsDropdown;
    public TMP_Dropdown ResolutionDropDown;

    private void Start()
    {
        resolutions = Screen.resolutions;

        resolutionsDropwdown.ClearOptions();

        List<string> resolutionsOptions = new List<string>();

        int currentResoltutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            resolutionsOptions.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width &&
               resolutions[i].height == Screen.currentResolution.height)
            {
                currentResoltutionIndex = i;
            }
        }

        resolutionsDropwdown.AddOptions(resolutionsOptions);
        resolutionsDropwdown.value = currentResoltutionIndex;
        resolutionsDropwdown.RefreshShownValue();

        audioMixer.SetFloat("MasterVolume", Mathf.Log10(MasterVolumeSlider.value) * 20);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
