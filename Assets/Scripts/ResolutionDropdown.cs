using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class ResolutionDropdown : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown;

    private Resolution[] _resolutions;

    void Start()
    {
        // Get the available screen resolutions
        _resolutions = Screen.resolutions;

        // Sort resolutions by width and height in descending order
        _resolutions = _resolutions
            .GroupBy(resolution => new { resolution.width, resolution.height })
            .Select(group => group.First())
            .OrderByDescending(resolution => resolution.width * resolution.height)
            .ToArray();

        // Clear the dropdown options
        resolutionDropdown.ClearOptions();

        // Create a list of resolution strings
        List<string> resolutionOptions = new List<string>
        {
            "Fullscreen"
        };

        resolutionOptions.AddRange(_resolutions
            .Select(resolution =>
                $"{resolution.width} x {resolution.height}")
            .ToList()
        );

        // Add the resolution options to the dropdown
        resolutionDropdown.AddOptions(resolutionOptions);

        // Set the default resolution to the current screen resolution
        int savedResolutionIndex = PlayerPrefs.GetInt("SelectedResolutionIndex", FindCurrentResolutionIndex());
        resolutionDropdown.value = savedResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    // Find the index of the current screen resolution in the resolutions array
    private int FindCurrentResolutionIndex()
    {
        if (Screen.fullScreen)
            return 0;

        Resolution currentResolution = Screen.currentResolution;

        for (int i = 0; i < _resolutions.Length; i++)
        {
            if (_resolutions[i].width == currentResolution.width && _resolutions[i].height == currentResolution.height)
            {
                return i+1;
            }
        }

        // If the current resolution is not in the list, return 0 as default
        return 0;
    }

    // Called when the dropdown value changes
    public void OnResolutionChanged(int resolutionIndex)
    {
        bool fullScreen = true;
        
        if (resolutionIndex == 0)
        {
            fullScreen = true;
        }
        else
        {
            if (Screen.fullScreen == true)
            {
                    fullScreen = true;
            }
            else
            {
                fullScreen = false;
            }
            
            resolutionIndex -= 1;
        }

        // Set the selected resolution
        Resolution selectedResolution = _resolutions[resolutionIndex];
        Screen.SetResolution(selectedResolution.width, selectedResolution.height, fullScreen);
        Screen.fullScreen = fullScreen;
        PlayerPrefs.SetInt("SelectedResolutionIndex", resolutionIndex);
    }
}
