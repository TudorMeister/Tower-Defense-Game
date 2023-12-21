using UnityEngine;

public class ParabolicBullet : Bullet {
    public LayerMask EntityLayer;
    public float DamageRadius = 6f;
    private Vector3 _targetPosition;
    private Vector3 _initialPosition;

    private float height;
    private float duration;
    private float elapsedTime = 0f;
    
    void Start()
    {
        _initialPosition = transform.position;
        _targetPosition = _target.transform.position;
        Vector3 direction = _initialPosition - _targetPosition;
        float distance = Mathf.Abs(direction.magnitude);
        height = -distance / 2f;
        duration = distance / FixedSpeed;
    }

    private Vector3 CalculateParabolaPoint(Vector3 start, Vector3 end, float height, float t)
    {
        float parabolicT = t * 2 - 1;

        Vector3 result = Vector3.Lerp(start, end, t);
        result.y += (parabolicT * parabolicT - 1) * height;

        return result;
    }

    private void Update()
    {
        MoveAlongParabola();
    }

    private void MoveAlongParabola()
    {
        if (elapsedTime <= duration)
        {
            float t = elapsedTime / duration;

            // Calculate the position on the parabola
            Vector3 parabolaPoint = CalculateParabolaPoint(_initialPosition, _targetPosition, height, t);

            // Update the object's position
            transform.position = parabolaPoint;

            // Increment the elapsed time
            elapsedTime += Time.deltaTime;
        }
        else{
            HitTarget();
        }
    }

    protected new void HitTarget () {
        //GameObject effect = (GameObject) Instantiate(impactEffect, transform.position, transform.rotation);
        //Destroy(effect, 2f);
        //Destroy(_target.gameObject);
        DamageEnemiesInRadius();
        Destroy(gameObject);
    }

    private void DamageEnemiesInRadius() {
        // Create a sphere in 3D space and find all colliders within it
        Collider[] colliders = Physics.OverlapSphere(_targetPosition, DamageRadius, EntityLayer);

        // Process the found entities
        foreach (Collider collider in colliders)
        {
            Destroy(collider.gameObject);
        }
    }
}
