using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallNode : MonoBehaviour {

    public Color hoverColor;
    public Vector3 heightOffset;

    private GameObject turret;

    private Renderer rend;
    private Color startColor;

    void Start () {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    void OnMouseDown () {
        if (turret) {
            Debug.Log("Can't build there!");
        }

        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + heightOffset, transform.rotation);
    }

    void OnMouseEnter() {
        rend.material.color = hoverColor;
    }

    void OnMouseExit () {
        rend.material.color = startColor;
    }
}
