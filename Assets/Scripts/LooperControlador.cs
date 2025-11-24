using UnityEngine;

public class LooperControlador : MonoBehaviour
{
    private Vector3 posicao_inicio;
    private Vector3 posicao_fim;
    public int contadorDeLoops = 0;
    public GameObject[] objetos_spawnaveis = new GameObject[2];

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        posicao_inicio =transform.Find("Inicio").transform.position;
        posicao_fim = transform.Find("Fim").transform.position;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public void loop(GameObject Player)
    {
        Vector3 posicao_antiga_player = Player.transform.position;
        posicao_antiga_player.z = posicao_inicio.z;
        Player.transform.position = posicao_antiga_player;
        contadorDeLoops += 1;
        spawnaObj();
       
    }
    
    private void spawnaObj()
    {
        Vector3 posicao_mensagem = posicao_fim;
        posicao_mensagem.z += 7;
        

         switch (contadorDeLoops)
        {
            case 3:
                objetos_spawnaveis[0].transform.position = posicao_mensagem;
                objetos_spawnaveis[0].SetActive(true);
                break;
                
            case 6:
                objetos_spawnaveis[1].transform.position = posicao_mensagem;
                objetos_spawnaveis[1].SetActive(true);
                objetos_spawnaveis[2].SetActive(true);
                break;
            
                
        }
        
    }
}
