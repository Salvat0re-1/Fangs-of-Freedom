using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class ObjetoDaño : MonoBehaviour
{
    public GameObject sangrePrefab; // Referencia al Prefab de la Sangre
    public Animator animator;
    public AudioSource clip;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.SendMessage("RecibirDaño");
        }
    }

    public void RecibirAtaque()
    {
        // Reproducir la animación "deathh" en el animator
        animator.Play("deathh");
        clip.Play();


        // Esperar a que la animación termine antes de destruir el objeto
        StartCoroutine(DestruirDespuesDeAnimacion());
    }

    private IEnumerator DestruirDespuesDeAnimacion()
    {
        // Esperar un frame para que la animación comience
        yield return null;

        // Esperar hasta que la animación termine
        while (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
        {
            yield return null;
        }

        // Obtener la posición actual del transform
        Vector3 posicionActual = transform.position;

        // Ajustar la posición en el eje Y
        float offsetY = 2f; // Puedes ajustar este valor según tus necesidades
        Vector3 nuevaPosicion = new Vector3(posicionActual.x, posicionActual.y + offsetY, posicionActual.z);

        // Instanciar la sangre con la nueva posición
        Instantiate(sangrePrefab, nuevaPosicion, Quaternion.identity);

        // Destruir el objeto
        Destroy(gameObject);
    }

}
