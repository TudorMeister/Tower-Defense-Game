using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    public string targetSceneName;

    public void SwitchScene()
    {
        SceneManager.LoadScene(targetSceneName);
    }
}
