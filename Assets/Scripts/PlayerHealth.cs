using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int life = 1;
    public float respawnDelay = 1.0f; // segundos antes de reiniciar cena
    public string killTag = "Kill";

    private bool dead = false;

    
    private void OnTriggerEnter(Collider other)
    {
        if (dead) return;
        if (other.CompareTag(killTag))
        {
            Die();
        }
    }

    void Die()
    {
        dead = true;
        // aqui: parar controle do jogador
        //var controller = GetComponent<PlayerController>(); // se tiver um script de controle
        //if (controller != null) controller.enabled = false;

        // animação/som (opcional)
        AudioSource deathSound = gameObject.GetComponent<AudioSource>();
        if (deathSound != null) deathSound.Play();

        // desabilitar visual/collider opcional
        var rend = GetComponentInChildren<Renderer>();
        if (rend != null) rend.enabled = false;

        // reinicia cena após delay
        Invoke(nameof(RestartScene), respawnDelay);
    }

    void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
