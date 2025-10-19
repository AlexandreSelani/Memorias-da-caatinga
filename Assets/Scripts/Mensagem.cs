using UnityEngine;

public class Mensagem : MonoBehaviour
{
    public string mensagem;
    public string PlayerTag = "Player";
    private AudioSource somDePapel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        somDePapel = gameObject.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag(PlayerTag))
        {
            AudioSource.PlayClipAtPoint(somDePapel.clip, transform.position);
            Debug.Log(mensagem);
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
