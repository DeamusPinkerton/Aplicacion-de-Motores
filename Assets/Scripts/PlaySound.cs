using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public AudioSource button;

    public void PlaySoundEffect()
    {
        button.Play();
    }
}
