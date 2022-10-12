using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    private Camera MainCamera;
    private Collider BladeCollider;
    private bool Slicing;

    public Vector3 direction { get; private set; }
    public float SliceForce = 5f;
    public float MinSliceVelocity = 0.01f;

    private void Awake()
    {
        MainCamera = Camera.main;
        BladeCollider = GetComponent<Collider>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartSlicing();

        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopSlicing();
        }
        else if (Slicing)
        {
            ContinueSlicing();
        }
    }
    private void OnEnable()
    {
        StopSlicing();
    }
    private void OnDisable()
    {
        StopSlicing();
    }

    private void StartSlicing()
    {
        Vector3 newPosition = MainCamera.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = -1f;

        transform.position = newPosition;

        Slicing = true;
        BladeCollider.enabled = true;
    }
    private void StopSlicing()
    {
        Slicing = false;
        BladeCollider.enabled = false;
    }
    private void ContinueSlicing()
    {
        Vector3 newPosition = MainCamera.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = -1f;

        direction = newPosition - transform.position;

        float velocity = direction.magnitude / Time.deltaTime;
        BladeCollider.enabled = velocity > MinSliceVelocity;

        transform.position = newPosition;
    }


}
