using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITurretBase
{
    long Health { get; set; }
}

public interface ITurretOffensive
{
    Transform Target { get; set; }
    float ShotRate { get; set; }
    float TimeUntilNextShot { get; set; }
    float TurnSpeed { get; set; }
    GameObject BulletPrefab { get; set; }
    Transform FirePoint { get; set; }

    void Update();
    void Shoot();
}

public class Turret : MonoBehaviour, ITurretBase, ITurretOffensive
{
    [Header("ITurretBase")]
    [SerializeField] private long health = 1000;
    public long Health { get { return health; } set { health = value; } }

    [Header("ITurretOffensive")]
    [SerializeField] private Transform target;
    public Transform Target { get { return target; } set { target = value; } }

    [SerializeField] private float shotRate = 2f;
    public float ShotRate { get { return shotRate; } set { shotRate = value; } }

    [SerializeField] private float timeUntilNextShot = 0f;
    public float TimeUntilNextShot { get { return timeUntilNextShot; } set { timeUntilNextShot = value; } }

    [SerializeField] private float turnSpeed = 10f;
    public float TurnSpeed { get { return turnSpeed; } set { turnSpeed = value; } }

    [SerializeField] private GameObject bulletPrefab;
    public GameObject BulletPrefab { get { return bulletPrefab; } set { bulletPrefab = value; } }

    [SerializeField] private Transform firePoint;
    public Transform FirePoint { get { return firePoint; } set { firePoint = value; } }

    public void Update()
    {
        if (Target)
        {
            Vector3 dir = target.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
            transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);

            if (TimeUntilNextShot <= 0f && Quaternion.Angle(transform.rotation, lookRotation) < 10.0f)
            {
                Shoot();
                timeUntilNextShot = 1f / shotRate;
            }

            timeUntilNextShot -= Time.deltaTime;
        }
    }

    public void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(BulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet)
        {
            bullet.Chase(Target);
        }
    }
}
