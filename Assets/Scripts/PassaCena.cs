using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PassaCena : MonoBehaviour
{
    public string PlayerTag = "Player";
    private Fade fade;
    //public GameObject proximaCena;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PlayerTag))
        {
            fade = other.GetComponent<Fade>();
            StartCoroutine(TrocarCenaDepoisDoFade());
            


        }
    }
    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator TrocarCenaDepoisDoFade()
{
    yield return StartCoroutine(fade.fadein_sequence());
    passaCena();
}
    public void passaCena()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("apertou");

    }

    public void cenaInicial()
    {
        SceneManager.LoadScene(0);
        Debug.Log("apertou");

    }
}
