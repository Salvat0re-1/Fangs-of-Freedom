using UnityEngine;
using UnityEngine.Audio;

public class Sangre : MonoBehaviour
{
    public AudioSource clip;
    private bool isPlaying = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SistemaHambre sistemaHambre = other.GetComponent<SistemaHambre>();
            if (sistemaHambre != null)
            {
                sistemaHambre.AumentarHambre(10);
                if (!isPlaying)
                {
                    clip.Play();
                    isPlaying = true;
                }
            }
        }
    }

    private void Update()
    {
        if (isPlaying && !clip.isPlaying)
        {
            isPlaying = false;
            gameObject.SetActive(false); // Desactivar el objeto cuando el sonido deja de reproducirse
            Invoke("ActivarSangre", 5f); // Activar el objeto después de 5 segundos
        }
    }

    private void ActivarSangre()
    {
        gameObject.SetActive(true); // Activar el objeto después de 5 segundos
    }
}