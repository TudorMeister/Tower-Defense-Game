using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class ShowHealthOfEnemy : MonoBehaviour
{
    public Enemy parent;
    public TextMeshPro text;

    void Start()
    {
        parent = GetComponentInParent<Enemy>();
        text  = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = parent.Health.ToString();
    }
}
