using UnityEngine;

public class BaseTurret : MonoBehaviour
{
    public int cost;


    [SerializeField]
    public int type;


    public BaseShootBehaviour ShootBehaviour;

    public BaseMovementBehaviour MovementBehaviour;

    public BaseTargetBehaviour TargetBehaviour;


    public void Start()
    {
        GameManager.Instance.turretList.Add(gameObject);
    }
}