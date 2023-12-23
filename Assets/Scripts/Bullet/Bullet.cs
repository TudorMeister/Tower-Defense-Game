using UnityEngine;

public class Bullet : MonoBehaviour {
    protected BaseTurret _launchedFrom;

    protected BaseEnemy _target;

    public float FixedSpeed {get; set;} = 70f;

    public int FixedDamage {get; set;} = 1;

    public void Chase(BaseTurret WhoLaunches, BaseEnemy Target) {
        _launchedFrom = WhoLaunches;
        _target = Target;
    }

    void Update() {
        if (!_target) {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = _target.transform.position - transform.position;
        float distFrame = FixedSpeed * Time.deltaTime;

        if (dir.magnitude <= distFrame) {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distFrame, Space.World);
    }

    protected void HitTarget () {
        //GameObject effect = (GameObject) Instantiate(impactEffect, transform.position, transform.rotation);
        //Destroy(effect, 2f);
        //Destroy(_target.gameObject);
        _target.TakeDamage(FixedDamage);
        _launchedFrom.TargetBehaviour.Targets.Remove(_target);
        Destroy(gameObject);
    }
}
