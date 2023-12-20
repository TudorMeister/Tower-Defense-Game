using System;
using UnityEngine;

public abstract class BaseShootBehaviour : MonoBehaviour
{
    public abstract Boolean CanShoot();
    public abstract void Shoot();
}