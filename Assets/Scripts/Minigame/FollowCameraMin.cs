using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCameraMin : MonoBehaviour
{
    public Transform playerTransform; //Referencia al transform del jugador
    public Vector3 offset; //Distancia entre la c�mara y el jugador

    void LateUpdate()
    {
        //Actualiza la posici�n de la c�mara para seguir al jugador
        transform.position = playerTransform.position + offset;
    }
}
