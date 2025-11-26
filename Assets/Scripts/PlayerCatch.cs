using UnityEngine;

public class PlayerCatch : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) // For 3D colliders
        {
            // Check if the object that entered the trigger is a collectible item
            if (other.CompareTag("Player")) 
            {
                Debug.Log("Item caught!");
                // Add the item to inventory, play sound, update score, etc.
                Destroy(gameObject); // Remove the item from the scene
            }
}   
}
