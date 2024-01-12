using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowMoney : MonoBehaviour
{
    public TextMeshProUGUI text;

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = (BuildManager.instance.money).ToString();
    }
}
