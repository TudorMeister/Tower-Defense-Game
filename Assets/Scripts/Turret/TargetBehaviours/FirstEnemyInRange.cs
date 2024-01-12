using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ClosestEnemyInRange : BaseTargetBehaviour
{
    public BaseTurret Turret;
    public override ISet<BaseEnemy> Targets { get; set; } = new HashSet<BaseEnemy>();

    public int TargetingRange;

    public override void AddTarget(BaseEnemy NewTarget)
    {
        Targets.Add(NewTarget);
    }

    public override void RemoveTarget(BaseEnemy Target)
    {
        Targets.Remove(Target);
    }

    private List<BaseEnemy> _targets = new();
    
    // public void Update()
    // {
    //     if (Targets.Count > 0)
    //     {
    //         BaseEnemy enemy = Targets.First();
    //         if (!enemy){
    //             Targets.Clear();
    //             return;
    //         }

    //         float dist = Vector3.Distance(Turret.transform.position, enemy.transform.position);
    //         if (dist > TargetingRange)
    //         {
    //             Targets.Clear();
    //             return;
    //         }
    //     }
    //     else
    //     {
    //         Enemy closestEnemy = null;

    //         float distMin = TargetingRange;
    //         foreach (Enemy enemy in _targets)
    //         {
    //             float dist = Vector3.Distance(Turret.transform.position, enemy.transform.position);
    //             if (dist < distMin)
    //             {
    //                 distMin = dist;
    //                 closestEnemy = enemy;
    //             }
    //         }

    //         if (closestEnemy)
    //         {
    //             AddTarget(closestEnemy);
    //         }
    //     }
    // }

    void Update() {
        if (Targets.Count > 0)
        {
            BaseEnemy enemy = Targets.First();
            if (!enemy){
                Targets.Clear();
                
                BaseEnemy closestEnemy = ChooseNextTarget();
                if (closestEnemy)
                {
                    AddTarget(closestEnemy);
                }            
            }
        }
        else if (_targets.Count > 0)
        {
            BaseEnemy closestEnemy = ChooseNextTarget();
            if (closestEnemy)
            {
                AddTarget(closestEnemy);
            }
        }
    }

    private BaseEnemy ChooseNextTarget()
    {
        BaseEnemy closestEnemy = null;

        _targets = _targets.Where(x => x).ToList();

        float distMin = TargetingRange;
        foreach (BaseEnemy enemyToTest in _targets)
        {
            float dist = Vector3.Distance(Turret.transform.position, enemyToTest.transform.position);
            if (dist < distMin)
            {
                distMin = dist;
                closestEnemy = enemyToTest;
            }
        }

        return closestEnemy;
    }

    public override void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to an enemy
        BaseEnemy enemy = other.GetComponent<BaseEnemy>();
        if (enemy != null)
        {
            // Enemy entered the turret's perimeter
            _targets.Add(enemy);
            if (Targets.Count == 0)
            {
                AddTarget(enemy);
            }
        }
    }

    public override void OnTriggerExit(Collider other)
    {
        // Check if the collider belongs to an enemy
        BaseEnemy enemy = other.GetComponent<BaseEnemy>();
        if (enemy != null)
        {
            // Enemy left the turret's perimeter
            _targets.Remove(enemy);
            if (Targets.Count > 0 && Targets.First() == enemy)
            {
                Targets.Clear();

                BaseEnemy closestEnemy = ChooseNextTarget();

                if (closestEnemy)
                {
                    AddTarget(closestEnemy);
                }
            }
        }
    }
}