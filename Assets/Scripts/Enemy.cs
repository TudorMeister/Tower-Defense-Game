using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int health = 3;


    public void TakeDamage(int damage)
    {
        health = health - damage;
        checkDeath();
    }

    void checkDeath()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
