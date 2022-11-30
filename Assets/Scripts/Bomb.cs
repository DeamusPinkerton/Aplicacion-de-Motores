using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private AudioSource SliceBomb;
    private void Start()
    {
        SliceBomb = GetComponentInChildren<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SliceBomb.Play();
            FindObjectOfType<GameManager>().Explode();
        }
    }
}
