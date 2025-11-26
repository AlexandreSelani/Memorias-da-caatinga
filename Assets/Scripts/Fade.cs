using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Fade : MonoBehaviour
{   
    public Canvas componenteDeUI; //componente geral de ui
    private GameObject painel_de_fade; //painel que realiza fade in/out
    public float duracao_fade_in; 
    private AudioSource somDePapel;
    public string PlayerTag = "Player";

    private bool jaAtivado = false;

    public float duracao_fade_out;
    private bool UIAtivo = true;

    //flags usadas para garantir que os fade-in/out vao ter sido concluidos
    private bool flag = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        painel_de_fade = componenteDeUI.transform.Find("Fade_in-out")?.gameObject;
        painel_de_fade.SetActive(UIAtivo);
        StartCoroutine(fadeout_sequence());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (jaAtivado) return;
        if (other.CompareTag(PlayerTag))
        {
            jaAtivado = true;
            AudioSource.PlayClipAtPoint(somDePapel.clip, transform.position);
            StartCoroutine(mostraMensagem());

            
        }
    }



    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator fadeout_sequence()
    {   
        UIAtivo = true;
        painel_de_fade.SetActive(UIAtivo);
        yield return StartCoroutine(fadeout());
        UIAtivo = false;
        painel_de_fade.SetActive(UIAtivo);
    }

    public IEnumerator fadein_sequence()
    {   
        UIAtivo = true;
        painel_de_fade.SetActive(UIAtivo);
        yield return StartCoroutine(fadein());
        
    }

    private IEnumerator fadeout()
    {
        Image fundoDoPainel = painel_de_fade.GetComponent<Image>();
        Color cor_painel = fundoDoPainel.color;
        float alpha_inicial_painel = cor_painel.a;
        float alpha_final_painel = 0f;
        float tempo = 0f;


        while (tempo < duracao_fade_out)
        {
            cor_painel.a = Mathf.Lerp(alpha_inicial_painel, alpha_final_painel, tempo / duracao_fade_out); // interpolação suave
            fundoDoPainel.color = cor_painel;
            tempo += Time.deltaTime;
            yield return null;
        }

        cor_painel.a = alpha_final_painel;                  // garante alfa final
        fundoDoPainel.color = cor_painel;


    }

    private IEnumerator mostraMensagem()
    {

        float duracao_fade = 1.75f;

        //passa a mensagem para a UI
        messageText.text = mensagem;
        //ativa a UI
        UIAtivo = true;
        painel.SetActive(UIAtivo);

        //fades
        yield return fadeIn(duracao_fade);
        yield return new WaitForSeconds(5f);
        yield return fadeOut(duracao_fade);

        //desativa a UI
        UIAtivo = false;
        painel.SetActive(UIAtivo);

        //destroi o objeto todo
        Destroy(gameObject);
    }
    
    
    private IEnumerator fadein()
    {

        Image fundoDoPainel = painel_de_fade.GetComponent<Image>();
        Color cor_painel = fundoDoPainel.color;
        float alpha_inicial_painel = cor_painel.a;
        float alpha_final_painel = 255f / 255f;


        float tempo = 0f;
        

        while (tempo < duracao_fade_in)
        {
            cor_painel.a = Mathf.Lerp(alpha_inicial_painel, alpha_final_painel, tempo / duracao_fade_in); // interpolação suave
            fundoDoPainel.color = cor_painel;
            tempo += Time.deltaTime;
            yield return null;
        }

        cor_painel.a = alpha_final_painel;                  // garante alfa final
        fundoDoPainel.color = cor_painel;

    }
}
