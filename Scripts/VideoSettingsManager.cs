using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class VideoSettingsManager : MonoBehaviour
{
    [SerializeField]
    TMP_Dropdown resolutionDropdown = null;
    [SerializeField]
    TMP_Dropdown fullscreenDropdown = null;
    [SerializeField]
    TMP_Dropdown qualityDropdown = null;

    List<Resolution> resolutions = new List<Resolution>();

    public void SetQuality (int level)
    {
        QualitySettings.SetQualityLevel(level);
    }

    public void SetResolution(int index)
    {
        Resolution resolution = resolutions[index];
        Screen.SetResolution(resolution.height, resolution.height, Screen.fullScreenMode);
        Camera.main.ResetAspect();
    }

    public void SetFullScreen (int index)
    {
        Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, (FullScreenMode)index);
        switch (index)
        {
            //Fullscreen borderless
            case 0:
                resolutionDropdown.gameObject.SetActive(true);
                break;
            //fullscreen
            case 1:
                resolutionDropdown.gameObject.SetActive(true);
                break;
            //Windowed
            case 2:
                Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, FullScreenMode.Windowed);
                resolutionDropdown.gameObject.SetActive(false);
                break;
        }
    }

    private void OnEnable()
    {
        //Set up resolution
        List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData>();
        resolutions = new List<Resolution>();
        float screenRatio = Round((float)Screen.width / (float)Screen.height);


        TMP_Dropdown.OptionData mainOption = new TMP_Dropdown.OptionData();
        mainOption.text = string.Format("{0} x {1}, ({2})", Screen.currentResolution.width, Screen.currentResolution.height, screenRatio);
        options.Add(mainOption);
        resolutions.Add(Screen.currentResolution);

        foreach (Resolution resolution in Screen.resolutions)
        {
            float ratio = Round((float)resolution.width / (float)resolution.height);
            if (ratio == screenRatio)
            {
                TMP_Dropdown.OptionData option = new TMP_Dropdown.OptionData();
                option.text = string.Format("{0} x {1}, ({2})", resolution.width, resolution.height, ratio);

                options.Add(option);
                resolutions.Add(resolution);
            }
        }


        resolutionDropdown.options = options;

        //Set up fullscreen
        fullscreenDropdown.value = (int)Screen.fullScreenMode;

        //Set up quality
        qualityDropdown.value = QualitySettings.GetQualityLevel();
    }

    float Round (float input)
    {
        return Mathf.Round(input * 100f) / 100f;
    }
}