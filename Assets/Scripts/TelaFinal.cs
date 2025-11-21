using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;
public class TelaFinal : MonoBehaviour
{   
    private TextMeshProUGUI texto;
    public GameObject passaCena;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        texto = GetComponentInChildren<TextMeshProUGUI>();
        StartCoroutine(rotina_principal());
    }

    // Update is called once per frame
    void Update()
    {
       

    }

    private IEnumerator rotina_principal()
    {
        yield return  StartCoroutine(fadeInTexto(5));
        yield return new WaitForSeconds(2.0f);
        var script = passaCena.GetComponent<PassaCena>(); 
        script.cenaInicial();
        //passaCena.passaCena();
    }
     private IEnumerator fadeInTexto(float duracao)
    {
        Color cor_texto = texto.color;

        float alpha_inicial = 0f;
        float alpha_final = 255f/255f;
        float tempo = 0f;

        while (tempo < duracao)
        {
            cor_texto.a = Mathf.Lerp(alpha_inicial, alpha_final, tempo / duracao);// interpolação suave
            texto.color = cor_texto;
            tempo += Time.deltaTime;
            yield return null;
        }

        cor_texto.a = alpha_final;
        texto.color = cor_texto;

    }
}
