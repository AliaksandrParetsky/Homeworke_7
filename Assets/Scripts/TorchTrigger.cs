using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchTrigger : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    private void Start()
    {
        audioSource.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        audioSource.Play();
    }

    private void OnTriggerExit(Collider other)
    {
        audioSource.Stop();
    }
}
