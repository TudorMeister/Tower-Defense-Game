using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowHealth : MonoBehaviour
{
    public Target parent;
    public TextMeshProUGUI text;

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = parent.health.ToString();
    }
}
