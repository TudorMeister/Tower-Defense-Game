using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHighlight : MonoBehaviour
{
    public Color hoverColor;
    private Renderer _rend;
    public Color _startColor;
    void Start()
    {
        _rend = GetComponent<Renderer>();
        //_startColor = _rend.material.color;
        _rend.material.color = hoverColor;
        foreach (Material material in _rend.materials)
        {
            material.color = hoverColor;
        }
    }
}
