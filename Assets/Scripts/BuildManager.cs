using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    public int startingMoney = 50;
    public int money = 0;

    public UpgradeUI upgradeUI;

    public Canvas uiCanvas;

    public BaseTurret standardTurretPrefab;
    public BaseTurret canonBallTurretPrefab;
    public BaseTurret freezeTurretPrefab;
    public BaseTurret machineGunTurretPrefab;

    void Awake()
    {
        if (instance)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;

        money = startingMoney;
    }

    private BaseTurret turretToBuild;

    public BaseTurret GetTurretToBuild()
    {
        return turretToBuild;
    }

    public void SetTurretToBuild(BaseTurret turret)
    {
        turretToBuild = turret;
    }
}
