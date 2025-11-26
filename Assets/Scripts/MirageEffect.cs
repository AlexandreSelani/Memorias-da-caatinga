using UnityEngine;

public class MirageEffect : MonoBehaviour
{
   public GameObject objectToDisappear;
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("Player"))
        {
           if(objectToDisappear != null)
            {
                objectToDisappear.SetActive(false);
            }
        }
        
    }
}
