using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombCheck : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bomb"))
        {
            FindObjectOfType<TutorialManager>().bombtcheck();
        }
        if (other.CompareTag("Fruit"))
        {
            FindObjectOfType<TutorialManager>().fruitcheck();
        }
        if (other.CompareTag("Rotten"))
        {
            FindObjectOfType<TutorialManager>().rottencheck();
        }
    }
}
