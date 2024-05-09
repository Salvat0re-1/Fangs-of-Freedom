using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueJugador : MonoBehaviour
{
    public KeyCode teclaAtaque = KeyCode.Space; // Tecla para realizar el ataque
    public float rangoAtaque = 2f; // Rango máximo de ataque
    public LayerMask capaEnemigo; // Capa que identifica al enemigo

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator no encontrado en el objeto " + gameObject.name);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(teclaAtaque))
        {
            Atacar();
        }
    }

    private void Atacar()
    {
        if (animator != null)
        {
            animator.SetTrigger("atack"); // Activa la animación de ataque
        }
        else
        {
            Debug.LogError("Animator no inicializado en AtaqueJugador");
        }

        // Detectar colisión con el enemigo dentro del rango de ataque
        Collider2D[] enemigos = Physics2D.OverlapCircleAll(transform.position, rangoAtaque, capaEnemigo);
        foreach (Collider2D enemigo in enemigos)
        {
            enemigo.SendMessage("RecibirAtaque"); // Llama al método RecibirAtaque en el enemigo
        }
    }
}
