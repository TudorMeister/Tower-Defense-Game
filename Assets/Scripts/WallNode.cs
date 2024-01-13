using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallNode : MonoBehaviour
{
    public Color hoverColor;
    public bool toggleCanvas = true;

    public Canvas canvas;

    private Renderer _rend;
    private Color _startColor;
    private GameObject _lastSelectedTurret;
    public bool _isOccupied = false;
    private WallNode _lastSelectedNode;
    private BuildManager _buildManager;
    private Shop _shopScript;

    void Start()
    {
        _rend = GetComponent<Renderer>();
        _startColor = _rend.material.color;
        _buildManager = BuildManager.instance;
        canvas = FindObjectOfType<Shop>().GetComponentInParent<Canvas>();
        canvas.enabled = false;
        _shopScript = FindObjectOfType<Shop>();
        //Debug.Log(_shopScript);
    }

    void OnMouseDown()
    {
        canvas.enabled = true;
        _shopScript.SetLastSelectedNode(this);
        GameObject turretToBuild = _buildManager.GetTurretToBuild();
    }

    public GameObject GetLastSelectedTurret()
    {
        return _lastSelectedTurret;
    }

    public bool HasTurret()
    {
        return _isOccupied;
    }

    public void SetTurret()
    {
        _isOccupied = true;
    }

    void OnMouseUp()
    {
        if (!canvas.enabled)
        {
            canvas.enabled = true;
        }
    }

    void OnMouseEnter()
    {
        if (_isOccupied)
            return;
        _rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        _rend.material.color = _startColor;
    }

    public void HideTurretSelectPanel()
    {
        canvas.enabled = false;
    }
}