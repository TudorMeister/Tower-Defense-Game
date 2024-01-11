using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallNode : MonoBehaviour
{
    public Color hoverColor;
    public Canvas canvas;
    public bool toggleCanvas = true;

    private Renderer _rend;
    private Color _startColor;
    private GameObject _lastSelectedTurret;
    private bool _isOccupied = false;
    private WallNode _lastSelectedNode;
    private BuildManager _buildManager;
    private Shop _shopScript;

    void Start()
    {
        _rend = GetComponent<Renderer>();
        _startColor = _rend.material.color;
        _buildManager = BuildManager.instance;
        canvas.enabled = false;
        _shopScript = FindObjectOfType<Shop>();
        Debug.Log(_shopScript);
    }

    void OnMouseDown()
    {
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