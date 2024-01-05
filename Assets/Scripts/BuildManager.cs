using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance;

    public int startingMoney = 50;
    public int money = 0;

    void Awake () {
        if (instance) {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;
        money = startingMoney;
    }

    public GameObject cannoballTurret;
    public GameObject freezeTurret;
    public GameObject machineGunTurret;

    public GameObject standardTurretPrefab;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            standardTurretPrefab = cannoballTurret;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            standardTurretPrefab = freezeTurret;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            standardTurretPrefab = machineGunTurret;
        }
    }


    public GameObject GetTurretToBuild () {
        return standardTurretPrefab;
    }
}
