using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoDaño2 : MonoBehaviour
{
    public ControlVidas controlVidas; // Referencia directa al componente ControlVidas

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            // No es necesario enviar el mensaje "RecibirDaño" nuevamente si ya estás haciendo que el jugador responda al recibir daño
            if (controlVidas != null)
            {
                controlVidas.RespawnPlayer(); // Llama al método RespawnPlayer de ControlVidas para respawneear al jugador
            }
        }
    }
}
