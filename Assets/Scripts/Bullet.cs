using UnityEngine;

public class Bullet : MonoBehaviour {

    private Transform _target;

    public float speed = 70f;

    public GameObject impactEffect;

    public void Chase(Transform target) {
        if (target) {
            _target = target;
        }
        return;
    }

    void Update() {
        if (!_target) {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = _target.position - transform.position;
        float distFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distFrame) {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distFrame, Space.World);
    }

    void HitTarget () {
        GameObject effect = (GameObject) Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effect, 2f);
        Destroy(_target.gameObject);
    }
}
