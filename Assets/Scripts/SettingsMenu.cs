using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void SetMasterVolume(float volume)
    {
        if (volume == -40)
        {
            audioMixer.SetFloat("MasterVolume", volume * 2);
        }
        else
        {
            audioMixer.SetFloat("MasterVolume", volume);
        }
    }
    public void SetMusicVolume(float volume)
    {
        if (volume == -40)
        {
            audioMixer.SetFloat("MusicVolume", volume * 2);
        }
        else
        {
            audioMixer.SetFloat("MusicVolume", volume);
        }
    }
    public void SetBGSVolume(float volume)
    {
        if (volume == -40)
        {
            audioMixer.SetFloat("BGSVolume", volume * 2);
        }
        else
        {
            audioMixer.SetFloat("BGSVolume", volume);
        }
    }
    public void SetSEVolume(float volume)
    {
        if (volume == -40)
        {
            audioMixer.SetFloat("SEVolume", volume * 2);
        }
        else
        {
            audioMixer.SetFloat("SEVolume", volume);
        }
    }
}
