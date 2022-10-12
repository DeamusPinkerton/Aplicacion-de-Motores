using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] Controller controller;
    [SerializeField] float speed = 5;

    private void Update()
    {
        transform.position += controller.GetMovementInput() * Time.deltaTime * speed;
    }
}
