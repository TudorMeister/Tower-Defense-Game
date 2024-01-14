using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public void Akriel () {
        SceneManager.LoadScene("LevelFinal_1");
    }
    public void Ezra () {
        SceneManager.LoadScene("LevelFinal_2");
    }
}
