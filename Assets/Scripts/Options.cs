using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour
{
    public void ToggleFullscreen()
    {
        Screen.fullScreen = true;
        print("Screen mode changed");
    }
}
