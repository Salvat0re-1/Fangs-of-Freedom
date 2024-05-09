using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private float fallDelay = 0.2f;
    private float destroyDelay = 7f;
    private float resetDelay = 7f;
    [SerializeField] private Rigidbody2D rb;
    private Vector2 initialPosition;

    private void Start()
    {
        // Guarda la posición inicial de la plataforma
        initialPosition = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(FallAndReset());
        }
    }

    private IEnumerator FallAndReset()
    {
        yield return new WaitForSeconds(fallDelay);
        rb.bodyType = RigidbodyType2D.Dynamic;
        yield return new WaitForSeconds(destroyDelay);
        rb.bodyType = RigidbodyType2D.Static;
        transform.position = initialPosition; // Devuelve la plataforma a su posición inicial
        yield return new WaitForSeconds(resetDelay);
        rb.bodyType = RigidbodyType2D.Dynamic; // Vuelve a habilitar la física para futuras caídas
    }
}
