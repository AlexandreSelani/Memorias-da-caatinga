using UnityEngine;

public class PlayerCatch : MonoBehaviour
{

    public AudioClip catchSoundClip; // Assign your audio clip in the Inspector
    private AudioSource audioSource;

    void Start()
    {   
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component not found on this GameObject!");
        }
        if (catchSoundClip == null)
        {
            Debug.LogWarning("Catch sound clip not assigned in the Inspector!");
        }
    }
    private void OnTriggerEnter(Collider other) // For 3D colliders
        {
            // Check if the object that entered the trigger is a collectible item
            if (other.CompareTag("Player")) 
            {
                 if (audioSource != null && catchSoundClip != null)
                {
                    audioSource.PlayOneShot(catchSoundClip);
                }
                Debug.Log("Item caught!");
                // Add the item to inventory, play sound, update score, etc.
                Destroy(gameObject); // Remove the item from the scene
            }
}   
}
