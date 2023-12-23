using UnityEngine;

public class FreezingLaser : Laser
{
    protected override void ApplyLaserEffect()
    {
        _target.SetMaxSpeed(_target.GetMaxSpeed()/2);
    }

    protected override void RemoveLaserEffect()
    {
        _target.SetMaxSpeed(_target.GetMaxSpeed()*2);
    }
}