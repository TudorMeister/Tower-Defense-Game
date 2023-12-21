using UnityEngine;

public class ChaseShootFromAllPoints : BaseShootBehaviour
{
    public GameObject BulletPrefab;

    [field:SerializeField]
    public override int BulletDamage {get; set;}

    [field:SerializeField]
    public override float BulletSpeed {get; set;}
    public BaseTurret Turret;

    public Transform[] FirePoints;

    public float ShootCooldownInSeconds;

    private float timeUntilNextShot = 0f;

    void Update(){
        if (timeUntilNextShot > 0)
            timeUntilNextShot -= Time.deltaTime;

        if (CanShoot())
            Shoot();
    }

    public override bool CanShoot()
    {
        if (Turret.TargetBehaviour.Targets.Count == 0)
            return false;

        BaseEnemy target = Turret.TargetBehaviour.Targets[0];
        if (!target)
            return false;

        Quaternion lookRotation = Quaternion.LookRotation(target.transform.position - Turret.transform.position);

        // Extract the y-axis Euler angles
        float currentAngleY = Turret.transform.rotation.eulerAngles.y;
        float targetAngleY = lookRotation.eulerAngles.y;

        // Calculate the angle difference on the y-axis
        float angleY = Mathf.Abs(Mathf.DeltaAngle(currentAngleY, targetAngleY));

        if (timeUntilNextShot <= 0f && angleY < 40)
        {
            return true;
        }

        return false;
    }

    public override void Shoot()
    {
        timeUntilNextShot = ShootCooldownInSeconds;
        
        foreach (Transform firePoint in FirePoints)
        {
            GameObject bulletGO = Instantiate(BulletPrefab, firePoint.position, firePoint.rotation);
            Bullet bullet = bulletGO.GetComponent<Bullet>();

            if (bullet)
            {
                bullet.FixedDamage = BulletDamage;
                bullet.FixedSpeed = BulletSpeed;
                bullet.Chase(Turret, Turret.TargetBehaviour.Targets[0]);
            }
        }
    }
}