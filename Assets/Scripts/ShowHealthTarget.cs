using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowHealthTarget : MonoBehaviour
{
    public Target parent;
    public TextMeshProUGUI text;

    void Start()
    {
        parent = FindObjectOfType<Target>();
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = (parent.health).ToString();
    }
}
