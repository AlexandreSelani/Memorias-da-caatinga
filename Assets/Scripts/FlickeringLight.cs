using UnityEngine;
using System.Collections;

public class flickering_light : MonoBehaviour
{
    public Light myLight;
    public float minIntensity = 0.5f;
    public float maxIntensity = 1.5f;

    public float interval = 1000.0f;
    private float timer;
    public float flickerSpeed = 0.01f; 

    // Update is called once per frame
    void Update()
    {
        LightFlicker();
        /*
        timer += Time.deltaTime;
        if(timer >= interval){    
            myLight.enabled = !myLight.enabled; // Toggle light on/off
            timer -= interval;
            //myLight.intensity = Random.Range(minIntensity, maxIntensity);
        }
        */
    }

    IEnumerator LightFlicker()
    {
        yield return new WaitForSeconds(flickerSpeed);
        myLight.intensity = Random.Range(minIntensity, maxIntensity);
    }
}
