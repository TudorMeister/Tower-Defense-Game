using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResolutionDropdown : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown;

    private Resolution[] resolutions;

    void Start()
    {
        // Get the available screen resolutions
        resolutions = Screen.resolutions;

        // Clear the dropdown options
        resolutionDropdown.ClearOptions();

        // Create a list of resolution strings
        List<string> resolutionOptions = new List<string>();

        // Add each resolution as a string to the list
        foreach (Resolution resolution in resolutions)
        {
            string option = resolution.width + " x " + resolution.height;
            resolutionOptions.Add(option);
        }

        // Add the resolution options to the dropdown
        resolutionDropdown.AddOptions(resolutionOptions);

        // Set the default resolution to the current screen resolution
        resolutionDropdown.value = FindCurrentResolutionIndex();
        resolutionDropdown.RefreshShownValue();
    }

    // Find the index of the current screen resolution in the resolutions array
    private int FindCurrentResolutionIndex()
    {
        Resolution currentResolution = Screen.currentResolution;

        for (int i = 0; i < resolutions.Length; i++)
        {
            if (resolutions[i].width == currentResolution.width && resolutions[i].height == currentResolution.height)
            {
                return i;
            }
        }

        // If the current resolution is not in the list, return 0 as default
        return 0;
    }

    // Called when the dropdown value changes
    public void OnResolutionChanged(int resolutionIndex)
    {
        // Set the selected resolution
        Resolution selectedResolution = resolutions[resolutionIndex];
        Screen.SetResolution(selectedResolution.width, selectedResolution.height, Screen.fullScreen);
    }
}
