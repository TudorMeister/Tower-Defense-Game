using UnityEngine;

public class BaseTurret : MonoBehaviour
{
    public int cost;

    public int upgradeCost;

    public Vector3 heightOffset;

    public BaseTurret upgradeTurret;

    public bool isUpgraded = false;

    [SerializeField]
    public int type;


    public BaseShootBehaviour ShootBehaviour;

    public BaseMovementBehaviour MovementBehaviour;

    public BaseTargetBehaviour TargetBehaviour;

    private BuildManager _buildManager;

    void Start()
    {
        GameManager.Instance.turretList.Add(gameObject);
        _buildManager = BuildManager.instance;
        if (upgradeTurret)
            upgradeTurret.isUpgraded = true;
    }

    public void OnMouseDown()
    {
        if (!isUpgraded && _buildManager.money - upgradeCost >= 0)
            _buildManager.upgradeUI.SetTarget(this);
        else if (isUpgraded)
            Debug.Log("Turret is already upgraded!");
        else
            Debug.Log("Not enough money!");
    }
}