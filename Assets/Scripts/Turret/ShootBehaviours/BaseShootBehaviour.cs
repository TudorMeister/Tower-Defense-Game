using UnityEngine;

public abstract class BaseShootBehaviour : MonoBehaviour
{
    public abstract bool CanShoot();
    public abstract void Shoot();

    public abstract int BulletDamage {get; set;}

    public abstract float BulletSpeed {get; set;}
}