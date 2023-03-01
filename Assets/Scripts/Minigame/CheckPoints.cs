using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour
{
    [SerializeField] GameObject Player;

    [SerializeField] List<GameObject> checkPoints;

    [SerializeField] Vector3 VectorPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CheckPoint"))
        {
            VectorPoint = Player.transform.position;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Trap") || other.CompareTag("Void"))
        {
            Player.transform.position = VectorPoint;
        }
    }


}
