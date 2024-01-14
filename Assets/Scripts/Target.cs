using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Target : MonoBehaviour
{
    public int health = 100;

    public GameObject lose;


    public void takeDamage(int damage)
    {
        health = health - damage;
        checkDeath();
    }

    public void checkDeath()
    {
        if (health <= 0) 
        {
            lose.SetActive(true);
            Invoke("ReloadScene", 5.0f);
        }
    }


    public void ReloadScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}
