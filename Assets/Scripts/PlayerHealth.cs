using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class PlayerHealth : MonoBehaviour
{
    public int life = 1;
    public float respawnDelay = 1.0f; // segundos antes de reiniciar cena
    public string killTag = "Kill";
    private Fade fade;
    private bool dead = false;

    void Start()
    {
        fade = GetComponent<Fade>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (dead) return;
        if (other.CompareTag(killTag))
        {
            StartCoroutine(Die());
        }
    }

    public IEnumerator Die()
    {
        dead = true;
        // aqui: parar controle do jogador
        //var controller = GetComponent<PlayerController>(); // se tiver um script de controle
        //if (controller != null) controller.enabled = false;
        StartCoroutine(fade.fadein_sequence());
        // animação/som (opcional)
        AudioSource deathSound = gameObject.GetComponent<AudioSource>();
        if (deathSound != null) deathSound.Play();

        // desabilitar visual/collider opcional
        var rend = GetComponentInChildren<Renderer>();
        if (rend != null) rend.enabled = false;


        yield return new WaitForSeconds(0.5f);
        // reinicia cena após delay
        Invoke(nameof(RestartScene), respawnDelay);
    }

    void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
