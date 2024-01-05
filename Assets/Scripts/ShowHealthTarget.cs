using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowHealthTarget : MonoBehaviour
{
    public Target parent;
    public TextMeshPro text;

    void Start()
    {
        parent = GetComponentInParent<Target>();
        text = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = (parent.health).ToString();
    }
}
