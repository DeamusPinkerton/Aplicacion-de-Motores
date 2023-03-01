using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmacionMenu : MonoBehaviour
{
    public GameObject pausemenu;

    public void Purchase()
    {
            pausemenu.SetActive(true);
    }
    public void Cancel()
    {
            pausemenu.SetActive(false);
    }

}
