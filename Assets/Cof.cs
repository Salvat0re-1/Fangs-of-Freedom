using UnityEngine;

public class Cof : MonoBehaviour
{
    public Finish finishInstance; // Asegúrate de asignar esta referencia en el Inspector de Unity

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Llama a la función NextLevel del script Finish después de 2 segundos
            Invoke("NextLevelWithDelay", 2f);
        }
    }

    private void NextLevelWithDelay()
    {
        finishInstance.NextLevel();
    }
}
