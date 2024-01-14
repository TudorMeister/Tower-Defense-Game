using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowWaveIndex : MonoBehaviour
{

    public TextMeshProUGUI text;


    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }



    void Update()
    {
        text.text = ("Wave: " + GameManager.Instance.GetWave().ToString());
    }

}
