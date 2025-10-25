using UnityEngine;

public class ativaFogo_fase2 : MonoBehaviour
{
    public GameObject fogo;
    private FogoDevorador script_do_fogo;
    public string playerTag = "Player";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        script_do_fogo = fogo.GetComponent<FogoDevorador>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            script_do_fogo.mover = true;
        }
    }
}
