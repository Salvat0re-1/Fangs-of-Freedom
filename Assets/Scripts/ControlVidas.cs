using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlVidas : MonoBehaviour
{
    public GameObject[] corazones;
    private int vidasRestantes = 3;
    public GameObject player; // Referencia al jugador
    private Animator jugadorAnimator; // Referencia al Animator del jugador

    void Start()
    {
        corazones = new GameObject[3]; // Inicializamos el arreglo con tamaño 3

        // Asignamos los corazones en el orden que queremos
        corazones[0] = GameObject.Find("Vida3");
        corazones[1] = GameObject.Find("Vida2");
        corazones[2] = GameObject.Find("Vida1");

        // Obtener referencia al jugador y su Animator
        player = GameObject.FindGameObjectWithTag("Player");
        jugadorAnimator = player.GetComponent<Animator>();
    }

    void RecibirDaño()
    {
        if (vidasRestantes > 0)
        {
            vidasRestantes--;
            corazones[vidasRestantes].SetActive(false); // Desactiva el corazón correspondiente
        }

        if (vidasRestantes <= 0)
        {
            jugadorAnimator.SetTrigger("hit"); // Activa la animación "hit"
            Invoke("RespawnDespuesEspera", 0.4f); // Llama a RespawnDespuesEspera después de 1 segundo
        }
    }

    void RespawnDespuesEspera()
    {
        RespawnPlayer(); // Llama al método para hacer respawn del jugador
    }


    public void RespawnPlayer()
    {
        if (player != null)
        {
            PlayerRespawn respawnScript = player.GetComponent<PlayerRespawn>();
            if (respawnScript != null)
            {
                respawnScript.Respawn();
                RestablecerVidas(); // Llama al método para restablecer los corazones
            }
        }
    }

    void RestablecerVidas()
    {
        vidasRestantes = 3; // Restablece las vidas
        foreach (GameObject corazon in corazones)
        {
            corazon.SetActive(true); // Activa los corazones nuevamente
        }
    }
}
