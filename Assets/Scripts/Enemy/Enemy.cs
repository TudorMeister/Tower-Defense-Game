using UnityEngine;


public class Enemy : BaseEnemy
{
    public override int Health { get; set; } = 3;

    public override int DamageToInflict {get; set;} = 1;

    [SerializeField]
    private int _range = 6;

    private Target Target;

    private void Awake()
    {
        GameManager.Instance.enemiesList.Add(this);
        Target = GameObject.Find("Target").GetComponent<Target>();
    }


    public override void TakeDamage(int damage)
    {
        Health -= damage;
        if (IsDead())
            Destroy(gameObject);
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
        GameManager.Instance.enemiesList.Remove(this);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _range);
    }



}
