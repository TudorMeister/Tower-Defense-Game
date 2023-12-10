using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Target : MonoBehaviour
{
    public int health = 100;


    public void takeDamage(int damage)
    {
        health = health - damage;
        checkDeath();
    }

    public void checkDeath()
    {
        if (health <= 0) 
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
    }
}
