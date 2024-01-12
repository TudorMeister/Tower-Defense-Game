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
    
    public void Update()
    {
        if (Targets.Count > 0)
        {
            BaseEnemy enemy = Targets.First();
            if (!enemy){
                Targets.Clear();
                return;
            }

            float dist = Vector3.Distance(Turret.transform.position, enemy.transform.position);
            if (dist > TargetingRange)
            {
                Targets.Clear();
                return;
            }
        }
        else
        {
            Enemy closestEnemy = null;

            float distMin = TargetingRange;
            foreach (Enemy enemy in GameManager.Instance.enemiesList)
            {
                if (Turret)
                {
                    float dist = Vector3.Distance(Turret.transform.position, enemy.transform.position);
                    if (dist < distMin)
                    {
                        distMin = dist;
                        closestEnemy = enemy;
                    }
                }
            }

            if (closestEnemy)
            {
                AddTarget(closestEnemy);
            }
        }
    }
}