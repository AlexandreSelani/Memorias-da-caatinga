using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class BotaoJogar : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void passaCena()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
