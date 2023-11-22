using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform target;

    [Header("Turret Attributes")]
    public float fireRate = 1f;
    public float fireCountDown = 0f;

    [Header("Unity Setup Fields")]
    public float turnSpeed = 10f;
    public GameObject bulletPrefab;
    public Transform firePoint;

    void Update()
    {
        if (target)
        {
            Vector3 dir = target.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
            transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);

            if (fireCountDown <= 0f && Quaternion.Angle(transform.rotation, lookRotation) < 20.0f)
            {
                Shoot();
                fireCountDown = 1f / fireRate;
            }

            fireCountDown -= Time.deltaTime;
        }
    }

    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet)
        {
            bullet.Chase(target);
        }
    }
}
