using UnityEngine;

public class BotaoVoltar : MonoBehaviour
{
    public Canvas componente_de_UI;
    private GameObject titulo;
    private GameObject botao_jogar;
    private GameObject botao_instrucoes;
    private GameObject instrucoes;
    private GameObject botao_voltar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        titulo = componente_de_UI.transform.Find("Titulo")?.gameObject;
        botao_jogar = componente_de_UI.transform.Find("Botao_jogar")?.gameObject;
        botao_instrucoes = componente_de_UI.transform.Find("Botao_Instrucoes")?.gameObject;
        botao_voltar = componente_de_UI.transform.Find("Botao_Voltar")?.gameObject;
        instrucoes = componente_de_UI.transform.Find("Instrucoes")?.gameObject;

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void ajustaBotoes(GameObject botao)
    {
        botao.transform.localScale = new Vector3(1, 1, 1);
    }
    public void esconde_instrucoes()
    {
        bool estado = true;
        titulo.SetActive(estado);
        ajustaBotoes(botao_jogar);
        botao_jogar.SetActive(estado);
        ajustaBotoes(botao_instrucoes);
        botao_instrucoes.SetActive(estado);

        instrucoes.SetActive(false);
        ajustaBotoes(botao_voltar);
        botao_voltar.SetActive(false);
    }
}
