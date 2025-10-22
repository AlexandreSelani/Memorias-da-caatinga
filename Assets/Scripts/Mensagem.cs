using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;
public class Mensagem : MonoBehaviour
{
    public string mensagem; //mensagem do papel
    public string PlayerTag = "Player";

    public Canvas componenteDeUI; //componente geral de ui
    private GameObject painel; //painel que contem o texto
    private TextMeshProUGUI messageText; //componente que representa o texto na tela
    private AudioSource somDePapel;

    private bool jaAtivado = false; //so por precaucao, pra ter certeza que nao vai dar mais de um trigger de colisao
    private bool UIAtivo = false;

    //flags usadas para garantir que os fade-in/out vao ter sido concluidos
    private bool flag1 = false;
    private bool flag2 = false;
    void Start()
    {


        //referencia o painel e desativa ele
        painel = componenteDeUI.transform.Find("Panel")?.gameObject;
        painel.SetActive(UIAtivo);

        messageText = painel.GetComponentInChildren<TextMeshProUGUI>();
        somDePapel = gameObject.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (jaAtivado) return;
        if (other.CompareTag(PlayerTag))
        {
            jaAtivado = true;
            AudioSource.PlayClipAtPoint(somDePapel.clip, transform.position);

            //solucao para desaparecer o pergaminho sem destruir o objeto
            GetComponent<MeshCollider>().enabled = false;
            transform.Find("scroll")?.gameObject.SetActive(false);

            StartCoroutine(mostraMensagem());

            
        }
    }
    // Update is called once per frame
    void Update()
    {

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

    private IEnumerator fadeInPainel(float duracao)
    {

        Image fundoDoPainel = painel.GetComponent<Image>();
        Color cor_painel = fundoDoPainel.color;
        float alpha_inicial_painel = cor_painel.a;
        float alpha_final_painel = 225f / 255f;


        float tempo = 0f;
        

        while (tempo < duracao)
        {
            cor_painel.a = Mathf.Lerp(alpha_inicial_painel, alpha_final_painel, tempo / duracao); // interpolação suave
            fundoDoPainel.color = cor_painel;
            tempo += Time.deltaTime;
            yield return null;
        }

        cor_painel.a = alpha_final_painel;                  // garante alfa final
        fundoDoPainel.color = cor_painel;

        flag1 = true;
    }

    private IEnumerator fadeOutPainel(float duracao)
    { 

        Image fundoDoPainel = painel.GetComponent<Image>();
        Color cor_painel = fundoDoPainel.color;
        float alpha_inicial_painel = cor_painel.a;
        float alpha_final_painel = 0f;
        float tempo = 0f;
        

        while (tempo < duracao)
        {
            cor_painel.a = Mathf.Lerp(alpha_inicial_painel, alpha_final_painel, tempo / duracao); // interpolação suave
            fundoDoPainel.color = cor_painel;
            tempo += Time.deltaTime;
            yield return null;
        }

        cor_painel.a = alpha_final_painel;                  // garante alfa final
        fundoDoPainel.color = cor_painel;

        flag1 = true;
    }

    private IEnumerator fadeInTexto(float duracao)
    {
        Color cor_texto = messageText.color;

        float alpha_inicial = 0f;
        float alpha_final = 255f/255f;
        float tempo = 0f;

        while (tempo < duracao)
        {
            cor_texto.a = Mathf.Lerp(alpha_inicial, alpha_final, tempo / duracao);// interpolação suave
            messageText.color = cor_texto;
            tempo += Time.deltaTime;
            yield return null;
        }

        cor_texto.a = alpha_final;
        messageText.color = cor_texto;

        flag2 = true;
    }

    private IEnumerator fadeOutTexto(float duracao)
    {
        Color cor_texto = messageText.color;

        float alpha_inicial = cor_texto.a;
        float alpha_final = 0f;
        float tempo = 0f;

        while (tempo < duracao)
        {
            cor_texto.a = Mathf.Lerp(alpha_inicial, alpha_final, tempo / duracao);// interpolação suave
            messageText.color = cor_texto;
            tempo += Time.deltaTime;
            yield return null;
        }

        cor_texto.a = alpha_final;
        messageText.color = cor_texto;

        flag2 = true;
    }

    private IEnumerator fadeIn(float duracao)
    {
        flag1 = false;
        flag2 = false;

        StartCoroutine(fadeInPainel(duracao));
        StartCoroutine(fadeInTexto(duracao));
        yield return new WaitUntil(() => flag1 && flag2);//garante que as duas corotinas terminaram
    }

    private IEnumerator fadeOut(float duracao)
    {   
        flag1 = false;
        flag2 = false;

        StartCoroutine(fadeOutPainel(duracao));
        StartCoroutine(fadeOutTexto(duracao));
        yield return new WaitUntil(() => flag1 && flag2);
    }
}
