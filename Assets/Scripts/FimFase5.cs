using UnityEngine;
using System.Collections;
public class FimFase5 : MonoBehaviour
{   
    public GameObject passaCena;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void Fim()
    {
        StartCoroutine(rotina_principal());
    }

    // Update is called once per frame
    private IEnumerator rotina_principal()
    {
        yield return new WaitForSeconds(3.0f);
        var script = passaCena.GetComponent<PassaCena>(); 
        script.passaCena();
    }
}
