using UnityEngine;
using UnityEngine.Audio;

public class Trampolin : MonoBehaviour
{
    public float fuerzaImpulso = 10f; // La fuerza del impulso hacia arriba
    public Animator animator;
    public AudioSource clip;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Verifica si el objeto que colisionó es el jugador
        {
            ApplyImpulse(collision.gameObject.GetComponent<Rigidbody2D>());
            animator.Play("actramp");
            clip.Play();
        }
    }

    private void ApplyImpulse(Rigidbody2D rb)
    {
        rb.velocity = Vector2.zero; // Reinicia la velocidad del jugador
        rb.AddForce(Vector2.up * fuerzaImpulso, ForceMode2D.Impulse); // Aplica el impulso hacia arriba
    }

    
}
