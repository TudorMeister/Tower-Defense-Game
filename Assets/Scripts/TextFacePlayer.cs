using UnityEngine;

public class FacePlayer : MonoBehaviour
{
    void Update()
    {
        // Get the player's position
        Vector3 playerPosition = Camera.main.transform.position;

        // Calculate the direction to the player only on the y-axis
        Vector3 directionToPlayer = new Vector3(playerPosition.x - transform.position.x, 0f, playerPosition.z - transform.position.z);

        // Face the player on the y-axis
        if (directionToPlayer != Vector3.zero)
        {

            Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer.normalized, Vector3.up);
            
            // Rotate 180 degrees from the target rotation
            transform.rotation = Quaternion.Euler(0f, targetRotation.eulerAngles.y + 180f, 0f);
        }
    }
}

