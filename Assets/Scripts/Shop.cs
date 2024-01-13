using UnityEngine;

public class Shop : MonoBehaviour
{
    public Canvas canvas;

    private BuildManager _buildManager;
    private WallNode _lastSelectedNode;

    void Start()
    {
        _buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret()
    {
        Debug.Log("Standard Turret Selected");
        canvas.enabled = false;
        _buildManager.SetTurretToBuild(_buildManager.standardTurretPrefab);
        BuildLastSelectedTurret();
    }

    public void SelectCanonBallTurret()
    {
        Debug.Log("CanonBall Turret Selected");
        canvas.enabled = false;
        _buildManager.SetTurretToBuild(_buildManager.canonBallTurretPrefab);
        BuildLastSelectedTurret();
    }

    public void SelectFreezeTurret()
    {
        Debug.Log("Freeze Turret Selected");
        canvas.enabled = false;
        _buildManager.SetTurretToBuild(_buildManager.freezeTurretPrefab);
        BuildLastSelectedTurret();
    }

    public void SelectMachineGunTurret()
    {
        Debug.Log("MachineGun Turret Selected");
        canvas.enabled = false;
        _buildManager.SetTurretToBuild(_buildManager.machineGunTurretPrefab);
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

            BaseTurret turretToBuild = _buildManager.GetTurretToBuild();
            if (_buildManager.money - turretToBuild.cost < 0)
                Debug.Log("Not enough money!");
            else
            {
                _buildManager.money -= turretToBuild.cost;
                if (turretToBuild != null)
                {
                    Instantiate(turretToBuild, _lastSelectedNode.transform.position + turretToBuild.heightOffset, Quaternion.identity);
                    _lastSelectedNode.SetTurret();
                }
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
