using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    private GlobalController _controller;
    public AudioMixer audioMixer;
    public Dropdown resolutionDropdown;

    Resolution[] resolutions;
    //finds and adds your native and all possuble resolutions to the dropdown
    private void Start()
    {
        _controller = GlobalController.instance;
       resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();//clears preset dropdown options

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for  (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue(); 
    }

    public void SetVolume(float volume)
        //voume controll
    {  
        _controller.volume = volume;
        audioMixer.SetFloat("Volume", volume);
    }

    public void SetFullscreen (bool isFullscreen)
        //sets full screem
    {
        Screen.fullScreen = isFullscreen;
        _controller.isFullscreen = isFullscreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        //sets the resolution to the one you picked
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        _controller.resolution = resolution;
    }
}

