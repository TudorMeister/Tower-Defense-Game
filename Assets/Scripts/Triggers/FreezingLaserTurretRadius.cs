using UnityEngine;

public class FreezingLaserTurretRadius : MonoBehaviour
{
    public MultipleEnemiesInRange Behaviour;

    void OnTriggerEnter(Collider other)
    {
        Behaviour.OnTriggerEnter(other);
    }

    void OnTriggerExit(Collider other)
    {
        Behaviour.OnTriggerExit(other);
    }
}