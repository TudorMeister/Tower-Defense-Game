using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LaserShootFromAllPoints : BaseShootBehaviour
{
    public GameObject LaserPrefab;

    public override int BulletDamage {get; set;} = 0;

    public override float BulletSpeed {get; set;} = 0;
    public BaseTurret Turret;

    public Transform[] FirePoints;

    void Update(){
        Shoot();
    }

    public override bool CanShoot()
    {
        return true;
    }

    private readonly ISet<BaseEnemy> _alreadyTargeted = new HashSet<BaseEnemy>();

    public override void Shoot()
    {
        foreach (BaseEnemy target in Turret.TargetBehaviour.Targets){
            if (!target || _alreadyTargeted.Contains(target))
                continue;

            Quaternion lookRotation = Quaternion.LookRotation(target.transform.position - Turret.transform.position);

            // Extract the y-axis Euler angles
            float currentAngleY = Turret.transform.rotation.eulerAngles.y;
            float targetAngleY = lookRotation.eulerAngles.y;

            // Calculate the angle difference on the y-axis
            float angleY = Mathf.Abs(Mathf.DeltaAngle(currentAngleY, targetAngleY));

            if (angleY < 40)
            {
                Shoot(target);
                _alreadyTargeted.Add(target);
            }
        }
    }

    private void Shoot(BaseEnemy enemy)
    {
        foreach (Transform firePoint in FirePoints)
        {
            GameObject laserGO = Instantiate(LaserPrefab, firePoint.position, firePoint.rotation);
            Laser laser = laserGO.GetComponent<Laser>();

            if (laser)
            {
                laser.StartLaser(Turret, enemy, firePoint);
            }
        }
    }
}