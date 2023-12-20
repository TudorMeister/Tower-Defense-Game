using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour
{
    public abstract int Health { get; set; }

    public abstract int DamageToInflict {get; set;}
    
    public abstract void TakeDamage(int Damage);

    public abstract bool IsDead();
}