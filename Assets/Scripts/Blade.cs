using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    private Camera MainCamera;
    private Collider BladeCollider;
    private bool Slicing;
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

    private void StartSlicing()
    {
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

    }


}
