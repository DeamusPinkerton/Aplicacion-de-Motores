using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", volume);
    }
    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", volume);
    }
    public void SetBGSVolume(float volume)
    {
        audioMixer.SetFloat("BGSVolume", volume);
    }
    public void SetSEVolume(float volume)
    {
        audioMixer.SetFloat("SEVolume", volume);
    }
}
