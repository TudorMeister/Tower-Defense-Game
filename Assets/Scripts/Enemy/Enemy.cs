using Pathfinding;
using UnityEngine;


public class Enemy : BaseEnemy
{
    [SerializeField]
    public override int Health { get; set; } = 10;

    public override int DamageToInflict {get; set;} = 1;

    [SerializeField]
    private int _range = 20;

    private Target Target;

    private AIPath _aiPath;

    public GameObject deathEffect;



    private void Awake()
    {
        GameManager.Instance.enemiesList.Add(this);
        Target = GameObject.Find("Target").GetComponent<Target>();
        _aiPath = GetComponent<AIPath>();
    }


    public override void TakeDamage(int damage)
    {
        Health -= damage;
        if (IsDead()) {
            Destroy(gameObject);
            BuildManager.instance.money += 1;
        }
    }

    public override bool IsDead()
    {
        return Health <= 0;
    }

    private void Update()
    {
        float dist = Vector3.Distance(transform.position, Target.transform.position);
        if (dist <= _range) 
        {
            Target.takeDamage(DamageToInflict);
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (!this.gameObject.scene.isLoaded) return;
        Instantiate(deathEffect, transform.position, transform.rotation);
        GameManager.Instance.enemiesList.Remove(this);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _range);
    }

    public override void SetMaxSpeed(float Speed)
    {
        _aiPath.maxSpeed = Speed;
    }

    public override float GetMaxSpeed()
    {
        return _aiPath.maxSpeed;
    }
}
