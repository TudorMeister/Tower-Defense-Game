using System.Linq;
using UnityEngine;

public class RotateTowardsTarget : BaseMovementBehaviour
{

    [SerializeField]
    private BaseTurret turret;

    [SerializeField]
    private int range;

    [SerializeField]
    private float turnSpeed;

    public void Update()
    {
        if (turret.TargetBehaviour.Targets.Count == 0)
            return;

        BaseEnemy target = turret.TargetBehaviour.Targets.First();
        if (!target)
            return;

        float dist = Vector3.Distance(turret.transform.position, target.transform.position);
        if (dist > range)
        {
            turret.TargetBehaviour.RemoveTarget(target);
            return;
        }
        
        Vector3 dir = target.transform.position - turret.transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(turret.transform.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        turret.transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }
}