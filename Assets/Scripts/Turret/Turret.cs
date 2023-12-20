using UnityEngine;

public interface ITurretBase
{
    long Health { get; set; }
}

public interface ITurretOffensive
{
    Enemy Target { get; set; }
    float ShotRate { get; set; }
    float TimeUntilNextShot { get; set; }
    float TurnSpeed { get; set; }
    GameObject BulletPrefab { get; set; }
    Transform FirePoint { get; set; }

    int Range { get; set; }


    void Update();
    void Shoot();
}

public class Turret : MonoBehaviour, ITurretBase, ITurretOffensive
{
    [Header("ITurretBase")]
    [SerializeField] private long health = 1000;
    public long Health { get { return health; } set { health = value; } }

    [Header("ITurretOffensive")]
    [SerializeField] private Enemy target;
    public Enemy Target { get { return target; } set { target = value; } }

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

    [SerializeField] private int range;
    public int Range { get { return range; } set {  range = value; } }


    public void Update()
    {
        //Debug.Log("1");
        if (Target)
        {
            float dist = Vector3.Distance(transform.position, target.transform.position);
            if (dist > range)
            {
                Target = null;
                return;
            }
            Vector3 dir = target.transform.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
            transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);

            // Extract the y-axis Euler angles
            float currentAngleY = transform.rotation.eulerAngles.y;
            float targetAngleY = lookRotation.eulerAngles.y;

            // Calculate the angle difference on the y-axis
            float angleY = Mathf.Abs(Mathf.DeltaAngle(currentAngleY, targetAngleY));

            if (TimeUntilNextShot <= 0f && angleY < 40)
            {
                Shoot();
                timeUntilNextShot = shotRate;
            }

            timeUntilNextShot -= Time.deltaTime;
        } else
        {
            float distMin = range;
            foreach (Enemy enemy in GameManager.Instance.enemiesList)
            {
                float dist = Vector3.Distance(transform.position, enemy.transform.position);
                if (dist < distMin)
                {
                    distMin = dist;
                    Target = enemy;
                    target = enemy;
                }
            }
        }
    }

    public void Shoot()
    {
        GameObject bulletGO = Instantiate(BulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet)
        {
            bullet.Chase(Target);
        }
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }


}