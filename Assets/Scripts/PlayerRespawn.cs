using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Vector3 startPosition;
    private Checkpoint lastCheckpoint;
    private ControlVidas controlVidas;

    void Start()
    {
        startPosition = transform.position;
        controlVidas = FindObjectOfType<ControlVidas>(); // Encuentra una instancia de ControlVidas en la escena
    }

    public void Respawn()
    {
        if (lastCheckpoint != null)
        {
            transform.position = lastCheckpoint.GetCheckpointPosition();
        }
        else
        {
            transform.position = startPosition;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Checkpoint"))
        {
            lastCheckpoint = other.GetComponent<Checkpoint>();
            Debug.Log("Checkpoint alcanzado!");
            Respawn(); // Llama al método para hacer respawn del jugador
            if (controlVidas != null)
            {
                controlVidas.RespawnPlayer(); // Llama al método RespawnPlayer de ControlVidas para restablecer los corazones

            }
        }
    }
}
