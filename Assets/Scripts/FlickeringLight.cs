using UnityEngine;
using System.Collections;

public class flickering_light : MonoBehaviour
{
    public Light myLight;
    public float minIntensity = 0.5f;
    public float maxIntensity = 1.5f;

    public float flickerSpeed = 0.1f; 

    // Update is called once per frame
    void Update()
    {
        
        myLight.intensity = Random.Range(minIntensity, maxIntensity);
        
    }

}
