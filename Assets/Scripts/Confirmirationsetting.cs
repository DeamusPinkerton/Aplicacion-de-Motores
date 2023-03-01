using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Confirmirationsetting : MonoBehaviour
{
    public GameObject resetmenu;

    public void Confirm()
    {
        resetmenu.SetActive(true);
    }
    public void Cancel()
    {
        resetmenu.SetActive(false);
    }
}
