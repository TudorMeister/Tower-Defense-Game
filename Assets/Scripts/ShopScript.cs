using UnityEngine;

public class ShopScript : MonoBehaviour
{
    BuildManager buildManager;

    private WallNode _lastSelectedNode;

    public Vector3 heightOffset;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret()
    {
        Debug.Log("Standard Turret Selected");
        buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);
        BuildLastSelectedTurret();
    }

    public void SelectCanonBallTurret()
    {
        Debug.Log("CanonBall Turret Selected");
        buildManager.SetTurretToBuild(buildManager.canonBallTurretPrefab);
        BuildLastSelectedTurret();
    }

    public void SelectFreezeTurret()
    {
        Debug.Log("Freeze Turret Selected");
        buildManager.SetTurretToBuild(buildManager.freezeTurretPrefab);
        BuildLastSelectedTurret();
    }

    public void SelectMachineGunTurret()
    {
        Debug.Log("MachineGun Turret Selected");
        buildManager.SetTurretToBuild(buildManager.machineGunTurretPrefab);
        BuildLastSelectedTurret();
    }

    private void BuildLastSelectedTurret()
    {
        if (_lastSelectedNode != null)
        {
            if (_lastSelectedNode.HasTurret())
            {
                Debug.Log("Can't build here!");
                return;
            }
            
            GameObject turretToBuild = buildManager.GetTurretToBuild();
            if (turretToBuild != null)
            {
                Instantiate(turretToBuild, _lastSelectedNode.transform.position + heightOffset, Quaternion.identity);
                _lastSelectedNode.SetTurret();
            }
        }
    }

    public void SetLastSelectedNode(WallNode wallNode)
    {
        _lastSelectedNode = wallNode;
    }

    public WallNode GetLastSelectedNode()
    {
        return _lastSelectedNode;
    }
}
