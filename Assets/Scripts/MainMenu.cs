using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource audioSource;

    private void Start()
    {
        // Obtener el AudioSource del botón en el inspector
        audioSource = GetComponent<AudioSource>();

        // Asegurarse de que el audio no se reproduzca al inicio
        audioSource.Stop();
    }

    public void EscenaJuego()
    {
        // Reproducir el audio cuando se presiona el botón "Jugar"
        audioSource.Play();

        // Llamar al método LoadGameScene después de que termine el sonido
        Invoke("LoadGameScene", audioSource.clip.length);
    }

    public void Exit()
    {
        // Reproducir el audio cuando se presiona el botón "Salir"
        audioSource.Play();

        // Llamar al método QuitGame después de que termine el sonido
        Invoke("QuitGame", audioSource.clip.length);
    }

    private void LoadGameScene()
    {
        SceneManager.LoadScene(1); // Cargar la escena del juego
    }

    private void QuitGame()
    {
        Application.Quit(); // Salir de la aplicación
    }
}
