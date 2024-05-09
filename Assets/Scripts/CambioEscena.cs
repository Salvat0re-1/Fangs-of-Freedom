using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioDeEscena : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Llama a la función NextLevel con un retraso de 2 segundos
            Invoke("NextLevelWithDelay", 2f);
        }
    }

    private void NextLevelWithDelay()
    {
        SceneController.instance.NextLevel();
    }
}
