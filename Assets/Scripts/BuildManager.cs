using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance;

    void Awake () {
        if (instance) {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }

    public GameObject doubleTurretPrefab;
    public GameObject canonBallTurretPrefab;
    public GameObject freezeTurretPrefab;
    public GameObject machineGunTurretPrefab;

    private GameObject turretToBuild;

    public GameObject GetTurretToBuild () {
        return turretToBuild;
    }

    public void SetTurretToBuild (GameObject turret) {
        turretToBuild = turret;
    }
}
