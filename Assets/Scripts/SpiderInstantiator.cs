using UnityEngine;

public class SpiderInstantiator : MonoBehaviour
{
    public GameObject spiderPrefab;
    public CameraAligner cameraAlignerScript;
    public float spawnDistance = 3f; 

    // NOVO: Variável pública para atribuir o ficheiro de áudio (AudioClip) no Inspector.
    public AudioClip jumpscareClip;

    // O método Start() e o 'private AudioSource jumpscareSound' foram removidos.
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Adicionada a verificação para o AudioClip.
            if (spiderPrefab == null || cameraAlignerScript == null || jumpscareClip == null)
            {
                Debug.LogError("As referências estão faltando (Prefab, CameraAligner, ou Jumpscare Clip)!");
                return;
            }

            // [LÓGICA DE SPAWN]
            Transform playerTransform = other.transform;
            Vector3 playerPosition = playerTransform.position;
            Vector3 playerBackward = -playerTransform.forward;
            Vector3 spawnPosition = playerPosition + (playerBackward * spawnDistance);
            spawnPosition.y = playerPosition.y; 

            Quaternion spiderRotation = playerTransform.rotation;
            spiderRotation *= Quaternion.Euler(0, 180, 0); 

            GameObject novaAranha = Instantiate(spiderPrefab, spawnPosition, spiderRotation);

            // [LÓGICA DA CÂMARA]
            cameraAlignerScript.target = novaAranha.transform;
            cameraAlignerScript.ativar = true;
            
            // CORREÇÃO DE ÁUDIO: Usa o método estático.
            // O som tocará uma única vez na posição do cubo e terminará completamente.
            AudioSource.PlayClipAtPoint(jumpscareClip, transform.position);
            
            FimFase5 terminaFase = GetComponent<FimFase5>();
            terminaFase.Fim();
            // [DESATIVAÇÃO]
            //gameObject.SetActive(false);
            //enabled = false;
        }

        
    }
}