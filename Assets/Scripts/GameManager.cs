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
            } else
            {
                canvas.SetActive(true);
            }
        }
    }

}
