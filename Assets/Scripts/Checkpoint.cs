using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Checkpoint : MonoBehaviour
{
    private Vector3 checkpointPosition;
    public AudioSource clip;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            checkpointPosition = other.transform.position;
            clip.Play();
        }

        
    }

    public Vector3 GetCheckpointPosition()
    {
        return checkpointPosition;
    }
}

