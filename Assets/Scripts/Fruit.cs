using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject Whole;
    public GameObject Sliced;

    private Rigidbody FruitRB;
    private Collider FruitCLR;
    private ParticleSystem JuicePteEf;
    private AudioSource SliceFrt;

    private void Awake()
    {
        FruitRB = GetComponent<Rigidbody>();
        FruitCLR = GetComponent<Collider>();
        JuicePteEf = GetComponentInChildren<ParticleSystem>();
        SliceFrt = GetComponentInChildren<AudioSource>();
    }

    private void Slice(Vector3 direction, Vector3 position, float force)
    {
        Whole.SetActive(false);
        Sliced.SetActive(true);

        FruitCLR.enabled = false;
        JuicePteEf.Play();
        SliceFrt.Play();

        float Angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Sliced.transform.rotation = Quaternion.Euler(0f, 0f, Angle);

        Rigidbody[] slices = Sliced.GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody slice in slices)
        {
            slice.velocity = FruitRB.velocity;
            slice.AddForceAtPosition(direction * force, position, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Blade blade = other.GetComponent<Blade>();
            Slice(blade.direction,blade.transform.position,blade.SliceForce);
        }
    }
}
