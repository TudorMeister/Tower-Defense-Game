using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MultipleEnemiesInRange : BaseTargetBehaviour
{
    public BaseTurret Turret;
    public override ISet<BaseEnemy> Targets { get; set; } = new HashSet<BaseEnemy>();

    public override void AddTarget(BaseEnemy NewTarget)
    {
        Targets.Add(NewTarget);
    }

    public override void RemoveTarget(BaseEnemy Target)
    {
        Targets.Remove(Target);
    }

    public void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to an enemy
        BaseEnemy enemy = other.GetComponent<BaseEnemy>();
        if (enemy != null)
        {
            // Enemy entered the turret's perimeter
            AddTarget(enemy);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        // Check if the collider belongs to an enemy
        BaseEnemy enemy = other.GetComponent<BaseEnemy>();
        if (enemy != null)
        {
            // Enemy left the turret's perimeter
            RemoveTarget(enemy);
        }
    }
}