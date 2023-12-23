using UnityEngine;

public abstract class Laser : MonoBehaviour {
    protected BaseTurret _launchedFrom;

    protected Transform _firePoint;

    protected BaseEnemy _target;

    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void StartLaser(BaseTurret WhoLaunches, BaseEnemy Target, Transform FirePoint) {
        _launchedFrom = WhoLaunches;
        _target = Target;
        _firePoint = FirePoint;
        ApplyLaserEffect();
    }

    void Update() {
        if (!_target || !_launchedFrom.TargetBehaviour.Targets.Contains(_target)) {
            Destroy(gameObject);
            RemoveLaserEffect();
            return;
        }

        lineRenderer.SetPosition(1, _firePoint.position);
        lineRenderer.SetPosition(0, _target.transform.position);
    }

    protected abstract void ApplyLaserEffect();

    protected abstract void RemoveLaserEffect();
}