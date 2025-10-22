using UnityEngine;

public class FloatAndRotate : MonoBehaviour
{
    public float amplitude = 0.5f;  // altura do sobe-desce
    public float frequency = 1f;    // velocidade do sobe-desce
    public float rotationSpeed = 30f; // graus por segundo

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // movimento senoidal (sobe-desce)
        float yOffset = Mathf.Sin(Time.time * frequency) * amplitude;
        transform.position = startPos + new Vector3(0, yOffset, 0);

        // rotação constante
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        
    }
}
