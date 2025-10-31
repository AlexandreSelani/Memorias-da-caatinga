using UnityEngine;

public class LooperFim : MonoBehaviour
{
    public string PlayerTag = "Player";
    private LooperControlador pai;
    private GameObject Player=null;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pai = GetComponentInParent<LooperControlador>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PlayerTag))
        {
            if (!Player)
            {
                Player = other.gameObject;
            }
            pai.loop(Player);

        }
    }
}
