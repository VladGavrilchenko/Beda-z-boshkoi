using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Setting : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown graphicsDrop;
    [SerializeField] private TMP_Dropdown resolutionDrop;
    private Resolution[] resolutions;

    private void Awake()
    {
        resolutionDrop.ClearOptions();
        List<string> options = new List<string>();
        resolutions = Screen.resolutions;
        int currentResolutionsIndx = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height + " " + resolutions[i].refreshRateRatio + "Hz";
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionsIndx = i;
            }
        }

        resolutionDrop.AddOptions(options);
        resolutionDrop.RefreshShownValue();
        Load(currentResolutionsIndx);
    }

    public void Load(int currentResolutionIndx)
    {
        if (PlayerPrefs.HasKey("GraphicIndx"))
        {
            graphicsDrop.value = PlayerPrefs.GetInt("GraphicIndx");
        }
        else
        {
            graphicsDrop.value = 3;
        }

        if (PlayerPrefs.HasKey("ResolutionIndx"))
        {
            resolutionDrop.value = PlayerPrefs.GetInt("ResolutionIndx");
        }
        else
        {
            resolutionDrop.value = currentResolutionIndx;
        }

        if (PlayerPrefs.HasKey("FullScreen"))
        {
            Screen.fullScreen = System.Convert.ToBoolean(PlayerPrefs.GetInt("ResolutionIndx"));
        }
        else
        {
            Screen.fullScreen = true;
        }
    }

    public void Save()
    {
        PlayerPrefs.SetInt("GraphicIndx", graphicsDrop.value);
        PlayerPrefs.SetInt("ResolutionIndx", resolutionDrop.value);
        PlayerPrefs.SetInt("FullScreen", System.Convert.ToInt32(Screen.fullScreen));
    }

    public void SetFullScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
        Save();
    }

    public void SetResolution(int resolutionIndx)
    {
        Resolution resolution = resolutions[resolutionIndx];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        Save();
    }

    public void SetQuality(int qualityIndx)
    {
        QualitySettings.SetQualityLevel(qualityIndx);
        Save();
    }
}
