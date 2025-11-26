using UnityEngine;

public class CameraAligner : MonoBehaviour
{
    public Transform target; 
    public bool ativar = false;
    
    // CORREÇÃO AQUI: A variável deve ser do tipo do script que você quer referenciar.
    private FirstPersonLook scriptControle; // O tipo é 'FirstPersonLook', não 'GameObject'
    private FirstPersonMovement andar;

    // Velocidade com que a câmara rotacionará para suavizar o movimento.
    [Range(1f, 10f)]
    public float rotationSpeed = 5f;

    
    void Start()
    {
        // O GetComponent deve retornar o script (componente) e atribuí-lo à variável do tipo correto.
        scriptControle = GetComponent<FirstPersonLook>();
        andar = GetComponentInParent<FirstPersonMovement>();
        
        if (scriptControle == null)
        {
            Debug.LogError("O script 'FirstPersonLook' não foi encontrado no objeto da câmara!");
        }
    }
    
    void LateUpdate()
    {
        if (target == null)
        {
            Debug.LogError("O alvo (target) da câmara não está atribuído no Inspector!");
            return;
        }

        if(ativar)
        {
            // Agora você pode acessar a propriedade 'controle' do script!
            // **Observação:** A variável 'controle' deve ser 'public' no script FirstPersonLook.
            if (scriptControle != null)
            {
                scriptControle.controle = false; 

            }

            if (andar != null)
            {   
                
                andar.speed = 0; 
                
            }
            
            Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position);

            // 3. Suaviza a rotação da câmara até o alvo.
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        // ativar=false;
        }
    }
}