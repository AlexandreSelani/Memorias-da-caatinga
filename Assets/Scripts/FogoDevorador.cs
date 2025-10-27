using UnityEngine;

public class FogoDevorador : MonoBehaviour
{
    public bool mover = false;
    public float velocidade = 3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mover)
        {
            Vector3 position = transform.position;
            position.z -= velocidade * Time.deltaTime;
            transform.position = position;
        }
    }
}
