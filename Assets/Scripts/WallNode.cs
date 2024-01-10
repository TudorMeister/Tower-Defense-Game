using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallNode : MonoBehaviour {

    public Color hoverColor;
    public Vector3 heightOffset;

    public Canvas canvas;
    public bool toggleCanvas = true;



    private GameObject turret;

    private Renderer _rend;
    private Color _startColor;
    private GameObject _lastSelectedTurret;
    private bool _isOccupied = false;
    private WallNode _lastSelectedNode;
    private BuildManager _buildManager;
    private ShopScript _shopScript;


    void Start () { 
        _rend = GetComponent<Renderer>();
        _startColor = _rend.material.color;
        _buildManager = BuildManager.instance;
        canvas.enabled = false;
        Debug.Log(canvas.enabled);
        _shopScript = FindObjectOfType<ShopScript>();

    }

    void OnMouseDown () {
        if (turret) {
            Debug.Log("Can't build there!");
            return;
        }

        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();

        if (turretToBuild.GetComponent<BaseTurret>().cost > BuildManager.instance.money)
        {
            Debug.Log("Not enough money!");
            return;   
        } else
        {
            BuildManager.instance.money -= turretToBuild.GetComponent<BaseTurret>().cost;
        }

        turret = (GameObject)Instantiate(turretToBuild, transform.position + heightOffset, transform.rotation);
    }

    void OnMouseEnter() {
        _rend.material.color = hoverColor;
    }

    void OnMouseExit () {
        _rend.material.color = _startColor;
    }
}
