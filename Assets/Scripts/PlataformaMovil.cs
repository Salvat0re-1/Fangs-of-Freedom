using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovil : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float moveSpeed = 2f;
    public bool playerOnPlatform;

    private Vector3 currentTarget;

    private void Start()
    {
        currentTarget = pointB.position; // Comienza moviéndose hacia el punto B
    }

    private void Update()
    {
        // Mueve la plataforma hacia el objetivo actual
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, moveSpeed * Time.deltaTime);

        // Si la plataforma llega al punto A o B, cambia de dirección
        if (transform.position == pointA.position)
        {
            currentTarget = pointB.position;
        }
        else if (transform.position == pointB.position)
        {
            currentTarget = pointA.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
            playerOnPlatform = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
            playerOnPlatform = false;
        }
    }
}
