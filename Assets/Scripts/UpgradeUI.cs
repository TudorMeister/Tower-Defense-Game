using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeUI : MonoBehaviour
{
    private BaseTurret _target;

    private BuildManager _buildManager;

    void Start()
    {
        _buildManager = BuildManager.instance;
        _buildManager.uiCanvas.enabled = false;
    }

    public void SetTarget (BaseTurret target)
    {
        _target = target;
        if (!_target.isUpgraded)
        {
            _buildManager.uiCanvas.enabled = !_buildManager.uiCanvas.enabled;
            transform.position = _target.transform.position;
        }
    }

    public void UpgradeTurret()
    {
        if (_target)
        {
            _buildManager.money -= _target.upgradeCost;
            BaseTurret _targetCopy = _target;
            Destroy(_target.gameObject);
            Instantiate(_targetCopy.upgradeTurret, _targetCopy.transform.position, Quaternion.identity);
            _buildManager.uiCanvas.enabled = false;
        }
    }
}
