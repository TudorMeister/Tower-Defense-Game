using System.Collections.Generic;
using UnityEngine;

public abstract class BaseTargetBehaviour : MonoBehaviour
{
    public abstract List<BaseEnemy> Targets {get; set;}

    public abstract void AddTarget(BaseEnemy NewTarget);

    public abstract void RemoveTarget(BaseEnemy Target);
}