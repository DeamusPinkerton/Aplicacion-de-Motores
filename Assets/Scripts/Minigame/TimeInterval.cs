using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeInterval : MonoBehaviour
{
    public float timeInterval = 1.0f; 
    private bool isObjectActive = true; 
    private float timeCounter = 0.0f;
    public GameObject Box;

    void Update()
    {

        timeCounter += Time.deltaTime; 

        if (timeCounter >= timeInterval) 
        {
            isObjectActive = !isObjectActive; 
            Box.SetActive(isObjectActive); 
            timeCounter = 0.0f; 
        }
    }
}
