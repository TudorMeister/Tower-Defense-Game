using UnityEngine;

public class Bullet : MonoBehaviour {

    private BaseEnemy _target;

    public float speed = 70f;

    public GameObject impactEffect;

    [SerializeField]
    private int damage = 1;

    public void Chase(BaseEnemy target) {
        _target = target;
    }

    void Update() {
        if (!_target) {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = _target.transform.position - transform.position;
        float distFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distFrame) {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distFrame, Space.World);
    }

    void HitTarget () {
        //GameObject effect = (GameObject) Instantiate(impactEffect, transform.position, transform.rotation);
        //Destroy(effect, 2f);
        //Destroy(_target.gameObject);
        _target.TakeDamage(damage);
        Destroy(gameObject);
    }
}
