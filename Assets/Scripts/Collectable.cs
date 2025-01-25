using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int points = 10; // Points to add when collected (optional)

    // Detect collision with the player
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the object colliding is the player
        {
            // Add points (or other effects)
            // GameManager.Instance.AddPoints(points); // Example for adding points (if you have a GameManager)

            // Destroy the collectible
            Destroy(gameObject);
        }
    }
}
