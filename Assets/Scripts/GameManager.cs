using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set;}
    public List<Enemy> enemiesList = new List<Enemy>();
    public GameObject canvas;

    public void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (canvas.activeSelf == true)
            {
                canvas.SetActive(false);
                Time.timeScale = 1.0f;
            } else
            {
                canvas.SetActive(true);
                Time.timeScale = 0.0f;
            }
        }
    }

    public void Resume()
    {
        canvas.SetActive(false);
        Time.timeScale = 1.0f;
    }

}
