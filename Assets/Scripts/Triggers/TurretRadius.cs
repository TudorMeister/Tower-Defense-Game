using UnityEngine;

public class TurretRadius : MonoBehaviour
{
    public BaseTargetBehaviour Behaviour;

    void OnTriggerEnter(Collider other)
    {
        Behaviour.OnTriggerEnter(other);
    }

    void OnTriggerExit(Collider other)
    {
        Behaviour.OnTriggerExit(other);
    }
}