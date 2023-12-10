using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int health = 3;
    [SerializeField]
    private int damage = 1;
    [SerializeField]
    private int range = 3;

    private Target Target;

    private void Awake()
    {
        GameManager.Instance.enemiesList.Add(this);
        Target = GameObject.Find("Target").GetComponent<Target>();
    }


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

    private void Update()
    {
        float dist = Vector3.Distance(transform.position, Target.transform.position);
        if (dist <= range) 
        {
            Target.takeDamage(damage);
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        GameManager.Instance.enemiesList.Remove(this);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }



}
